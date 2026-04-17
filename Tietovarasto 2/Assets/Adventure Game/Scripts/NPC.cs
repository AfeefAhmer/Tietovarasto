using UnityEngine;

public class Npc : MonoBehaviour
{
    private void Start()
    {
        LogManager.Instance?.LogEvent("NPC ilmestyi peliin: " + gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Varmistetaan että vain pelaaja triggeröi
        if (!other.CompareTag("Player")) return;

        StartDialogue();
    }

    public void StartDialogue()
    {
        Debug.Log("Keskustelu alkaa NPC:n kanssa: " + gameObject.name);

        LogManager.Instance?.LogEvent("NPC aloitti keskustelun: " + gameObject.name);
    }
}