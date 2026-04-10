using UnityEngine;

public class Npc : MonoBehaviour
{
    private void Start()
    {
        LogManager.Instance.LogEvent("NPC ilmestyi peliin: " + gameObject.name);
    }

    public void StartDialogue()
    {
        LogManager.Instance.LogEvent("NPC aloitti keskustelun: " + gameObject.name);
    }
}