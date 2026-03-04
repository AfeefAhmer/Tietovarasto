using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Health health;
    private int score = 0;

    [SerializeField] private TextMeshProUGUI scoreText;

    public int CurrentHealth => health.CurrentHealth;
    public int CurrentScore => score;

    private string savePath;

    private void Awake()
    {
        health = GetComponent<Health>();

        if (health == null)
            Debug.LogError("Health-komponentti puuttuu Player-objektilta!");

        savePath = Path.Combine(Application.persistentDataPath, "playerdata.json");
    }

    private void Start()
    {
        Load();
        UpdateScoreUI();
    }

    private void Update()
    {
        // Testinäppäimet
        if (Keyboard.current.tKey.wasPressedThisFrame)
            TakeDamage(1);

        if (Keyboard.current.hKey.wasPressedThisFrame)
            Heal(1);

        if (Keyboard.current.yKey.wasPressedThisFrame)
            Save();
    }

    public void TakeDamage(int amount)
    {
        health.Modify(-amount);
    }

    public void Heal(int amount)
    {
        health.Modify(amount);
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = $"Score: {score}";
    }

    public void Save()
    {
        PlayerData data = new PlayerData(this);
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);
        Debug.Log("Tallennettu tiedostoon: " + savePath);
    }

    public void Load()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

            // Päivitetään health oikein
            int deltaHealth = data.health - health.CurrentHealth;
            health.Modify(deltaHealth);

            // Päivitetään score
            score = data.score;

            Debug.Log("Tallennus ladattu.");
        }
        else
        {
            Debug.Log("Tallennustiedostoa ei löytynyt, aloitetaan alusta.");
            score = 0;
        }

        UpdateScoreUI();
    }
}