using UnityEngine;

public class AreaTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        LogManager.Instance.LogEvent("Pelaaja saapui alueelle: " + gameObject.name);
    }
}