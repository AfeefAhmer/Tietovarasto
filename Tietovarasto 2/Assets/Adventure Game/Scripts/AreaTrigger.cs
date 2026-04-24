using UnityEngine;

public class AreaTrigger : MonoBehaviour
{
    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggeriin osui: " + other.name);

        // Estetään useat triggeröinnit
        if (hasTriggered) return;

        // Tarkistetaan että kyseessä on pelaaja
        if (!other.CompareTag("Player")) return;

        hasTriggered = true;

        Debug.Log("Pelaaja saapui alueelle!");

        // Turvallinen logitus
        if (LogManager.Instance != null)
        {
            LogManager.Instance.LogEvent("Pelaaja saapui alueelle: " + gameObject.name);
        }
        else
        {
            Debug.LogWarning("LogManager puuttuu!");
        }
    }
}