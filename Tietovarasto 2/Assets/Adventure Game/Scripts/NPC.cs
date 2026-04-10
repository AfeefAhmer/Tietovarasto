using UnityEngine;

public class Npc : MonoBehaviour
{
    public void StartDialogue()
    {
        LogManager.Instance.LogEvent("NPC aloitti keskustelun: " + gameObject.name);
    }
}