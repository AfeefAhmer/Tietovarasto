using UnityEngine;
using System.IO;

public class SavePoint : MonoBehaviour
{
    private string saveFilePath;

    [System.Serializable]
    public class SaveData
    {
        public float playerX;
        public float playerY;
        public float playerZ;
    }

    private void Start()
    {
        saveFilePath = Application.persistentDataPath + "/savegame.json";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SavePlayerPosition(other.transform.position);
            Debug.Log("Peli tallennettu!");
        }
    }

    void SavePlayerPosition(Vector3 position)
    {
        SaveData data = new SaveData();
        data.playerX = position.x;
        data.playerY = position.y;
        data.playerZ = position.z;

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(saveFilePath, json);
    }
}