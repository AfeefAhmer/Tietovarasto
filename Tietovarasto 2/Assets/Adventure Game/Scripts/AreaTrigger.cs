using UnityEngine;

public class AreaTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        LogManager.Instance?.LogEvent("Pelaaja saapui alueelle: " + gameObject.name);
    }
}