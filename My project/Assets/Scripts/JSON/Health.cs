using UnityEngine;
using System.IO;
using TMPro;

/// <summary>
/// Health vastaa vain el‰m‰n m‰‰r‰st‰.
/// </summary>
public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;
    private Health health;

    [SerializeField] private TextMeshProUGUI hpText;

    public int CurrentHealth
    {
        get => currentHealth;
        set
        {
            currentHealth = value;
            UpdateHPText();
        }
    }

    void Start()
    {
        health = GetComponent<Health>();
        health.Load();
        UpdateHPText();
    }

    void Awake()
    {
        currentHealth = maxHealth;
    }

    /// <summary>
    /// positiivinen arvo --> parantaa
    /// negatiivinen arvo --> tekee vahinkoa
    /// </summary>
    public void Modify(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateHPText();
        Debug.Log("Health: " + currentHealth);
    }

    void UpdateHPText()
    {
        if (hpText != null)
        {
            hpText.text = "HP=" + currentHealth;
        }
    }

    public void Load()
    {
        Debug.Log("Testi: JSON-lataus k‰ynniss‰");

        string path = $"{Application.dataPath}/playerData.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);
            CurrentHealth = playerData.health;
        }
    }
}
