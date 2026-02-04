using UnityEngine;

/// <summary>
/// Health vastaa vain el‰m‰n m‰‰r‰st‰.
/// </summary>
public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    // Julkinen property nykyisen terveyden lukemiseen
    public int CurrentHealth
    {
        get { return currentHealth; }
    }

    /// <summary>
    /// positiivinen arvo --> parantaa
    /// negatiivinen arvo --> tekee vahinkoa
    /// </summary>
    public void Modify(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log("Health: " + currentHealth);
    }
}
