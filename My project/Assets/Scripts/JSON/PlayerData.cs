[System.Serializable]
public class PlayerData
{
    public int health;
    public int score;

    // Ker‰t‰‰n data Player-luokasta
    public PlayerData(Player player)
    {
        health = player.CurrentHealth;
        score = player.CurrentScore;
    }
}