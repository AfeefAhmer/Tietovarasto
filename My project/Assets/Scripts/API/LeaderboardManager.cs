using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using TMPro;
public class LeaderboardManager : MonoBehaviour
{
    // Korvaa porttinumero oman palvelimen porttinumerolla
    public string url = "http://localhost:5139/leaderboard";
    public TMP_Text leaderboardText;
    public void GetLeaderboard()
    {
        StartCoroutine(GetLeaderboardCoroutine());
    }
    IEnumerator GetLeaderboardCoroutine()
    {
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Virhe: " + request.error);
            yield break;
        }
        string json = request.downloadHandler.text;
        // Unity tarvitsee t‰m‰n tempun listalle
        string wrappedJson = "{\"scores\":" + json + "}";
        // Muuttaa JSON-tiedoston olioksi
        ScoreList list = JsonUtility.FromJson<ScoreList>(wrappedJson);
        ShowLeaderboard(list);
    }
    // N‰ytt‰‰ TOP 5 listan
    void ShowLeaderboard(ScoreList list)
    {
        leaderboardText.text = "TOP 5\n";
        for (int i = 0; i < list.scores.Length; i++)
        {
            var s = list.scores[i];
            leaderboardText.text += $"{i + 1}. {s.name} - {s.points}\n";
        }
    }
}