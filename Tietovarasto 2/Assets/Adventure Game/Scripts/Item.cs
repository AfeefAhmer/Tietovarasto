using UnityEngine;

public class Item : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        LogManager.Instance.LogEvent("Pelaaja keräsi esineen: " + gameObject.name);
    }
}