using SQLite;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

// Pelaajan pinkoodi ja lempinimi
public class PlayerLogin
{
    public string pincode { get; set; }
    public string nickname { get; set; }
}

// Kirjautuminen
public class Login : MonoBehaviour
{
    private string database = $"{Application.dataPath}/AdventureGame.db";

    [SerializeField] private TMP_InputField pincode;

    public bool IsLoginOK { get; private set; }

    public void HandleLogin()
    {
        var db = new SQLiteConnection(database);

        string sql = $"select * from Login where pincode = '{pincode.text}'";

        var players = db.Query<PlayerLogin>(sql);

        if (players.Count != 0)
        {
            print("Pelaaja löytyi");
            IsLoginOK = true;
        }

        db.Close();

        if (!IsLoginOK)
        {
            return;
        }

        SceneManager.LoadScene("EndGame");
    }
}