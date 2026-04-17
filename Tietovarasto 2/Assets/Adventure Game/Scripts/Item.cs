using UnityEngine;

public class Item : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (LogManager.Instance != null)
        {
            LogManager.Instance.LogEvent("Pelaaja keräsi esineen: " + gameObject.name);
        }
        else
        {
            Debug.LogWarning("LogManager puuttuu!");
        }

        // Estä uudelleen triggeröinti (valinnainen)
        gameObject.SetActive(false);
    }
}