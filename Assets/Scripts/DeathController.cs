using UnityEngine;


public class DeathController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            
            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
            playerController.KillPlayer();
            playerController.startPosiiton();
        }
    }

}
