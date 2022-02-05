using UnityEngine;

public class PowerUpSpeed : MonoBehaviour
{
    private PlayerMove player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            // Speed Stuff here
            player = other.GetComponent<PlayerMove>();
            player.ChangeSpeed(2);
            // Destroy This Powerup
            Destroy(gameObject);
        }
    }
}
