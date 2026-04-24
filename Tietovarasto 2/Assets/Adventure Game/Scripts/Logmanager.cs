using System;
using System.IO;
using TMPro;
using UnityEngine;

public class LogManager : MonoBehaviour
{
    public static LogManager Instance { get; private set; }

    private string logFilePath;
    private string textFileName;

    [SerializeField] private TMP_Text logText;

    private void Awake()
    {
        // ✔ Singleton korjaus
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        // Pysyvä tallennuspaikka
        logFilePath = Application.persistentDataPath + "/game_data/";
        textFileName = logFilePath + "game_log.txt";

        NewFolder();
        NewTextFile();

        LogEvent($"\nPeli alkaa: {DateTime.Now}");
        UpdateLogUI();
    }

    public void LogEvent(string text)
    {
        // varmistetaan että kansio + tiedosto on aina olemassa
        if (!Directory.Exists(logFilePath))
        {
            Directory.CreateDirectory(logFilePath);
        }

        if (!File.Exists(textFileName))
        {
            File.WriteAllText(textFileName, "<LOG START>\n");
        }

        File.AppendAllText(textFileName, $"{text}\n");
        Debug.Log($"Tiedosto päivitetty: {text}");

        UpdateLogUI();
    }

    private void OnDisable()
    {
        if (File.Exists(textFileName))
        {
            var endGameText = $"Peli päättyi: {DateTime.Now}----------------\n";
            File.AppendAllText(textFileName, endGameText);
        }
    }

    private void UpdateLogUI()
    {
        if (logText == null)
        {
            Debug.LogWarning("logText EI OLE asetettu Inspectorissa!");
            return;
        }

        if (!File.Exists(textFileName))
        {
            logText.text = "";
            return;
        }

        logText.text = File.ReadAllText(textFileName);
    }

    private void NewFolder()
    {
        if (!Directory.Exists(logFilePath))
        {
            Directory.CreateDirectory(logFilePath);
            Debug.Log("Uusi hakemisto luotu");
        }
    }

    private void NewTextFile()
    {
        if (!File.Exists(textFileName))
        {
            File.WriteAllText(textFileName, "<TALLETETTU DATA - Soveltava harjoitus>\n\n");
            Debug.Log("Uusi tiedosto luotu");
        }
    }

    public void DeleteFolder()
    {
        if (Directory.Exists(logFilePath))
        {
            Directory.Delete(logFilePath, true);
            Debug.Log("Kansio poistettu!");
        }

        UpdateLogUI();
    }

    public void DeleteFile()
    {
        if (File.Exists(textFileName))
        {
            File.Delete(textFileName);
            Debug.Log("Tiedosto poistettu!");
        }

        UpdateLogUI();
    }
}