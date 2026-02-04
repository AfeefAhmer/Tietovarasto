using UnityEngine;
using TMPro;

public class ClickerManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highscoreText;

    private int score = 0;

    void Start()
    {
        int highscore = PlayerPrefs.GetInt("HighScore", 0);
        highscoreText.text = "Highscore: " + highscore;
        UpdateScoreText();
    }

    public void Click()
    {
        score++;
        UpdateScoreText();
    }

    public void EndGame()
    {
        // Haetaan tallennettu highscore
        int highscore = PlayerPrefs.GetInt("HighScore", 0);

        // Tarkistetaan onko uusi enn‰tys
        if (score > highscore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();

            highscoreText.text = "Highscore: " + score;
        }

        // Nollataan score
        score = 0;

        // P‰ivitet‰‰n score-teksti
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
