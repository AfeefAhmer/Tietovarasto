using UnityEngine;

public class ScorePickup : MonoBehaviour
{
    [SerializeField] private int scoreValue = 5;

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();

        if (player != null)
        {
            player.AddScore(scoreValue);
            Destroy(gameObject);
        }
    }
}