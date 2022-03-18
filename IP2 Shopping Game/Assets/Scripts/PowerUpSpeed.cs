using UnityEngine;

public class PowerUpSpeed : MonoBehaviour
{
    private PlayerMove player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player 1") || other.transform.CompareTag("Player 2"))
        {
            // Speed Stuff here
            player = other.GetComponent<PlayerMove>();
            player.ChangeSpeed(2);
            // Destroy This Powerup
            Destroy(gameObject);
        }
    }
}
