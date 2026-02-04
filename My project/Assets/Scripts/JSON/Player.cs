using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Player vastaa pelaajan toiminnasta (liikkuminen, hyökkäys).
/// </summary>
public class Player : MonoBehaviour
{
    private Health health;

    void Awake()
    {
        health = GetComponent<Health>();
    }

    private void Start()
    {
        if (health == null)
        {
            Debug.LogError("Health-komponentti puuttuu");
        }

        TakeDamage(1);
    }

    private void Update()
    {
        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            TakeDamage(1);
        }

        if (Keyboard.current.hKey.wasPressedThisFrame)
        {
            Heal(1);
        }

        if (Keyboard.current.yKey.wasPressedThisFrame)
        {
            Save();
        }
    }

    public void TakeDamage(int amount)
    {
        health.Modify(-amount);
    }

    public void Heal(int amount)
    {
        health.Modify(amount);
    }

    // Tallenna pelaajan data JSON-tiedostoon
    public void Save()
    {
        PlayerData data = new PlayerData(this);
        string json = JsonUtility.ToJson(data);

        string path = Path.Combine(Application.persistentDataPath, "playerdata.json");
        File.WriteAllText(path, json);

        Debug.Log($"Pelaajan tiedot tallennettu tiedostoon: {path}");
    }
}
