[System.Serializable]
public class PlayerData
{
    public int health;

    public PlayerData(Player player)
    {
        health = player.GetComponent<Health>().CurrentHealth;
    }
}
