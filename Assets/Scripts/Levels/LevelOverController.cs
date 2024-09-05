using UnityEngine;


public class LevelOverController : MonoBehaviour
{
    public LevelCompletedController completed;

    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            Camera.main.transform.parent = null;
            LevelManager.Instance.MarkCurrentLevelComplete();
            player.SetActive(false);
            completed.PlayerWon();
        }
    }
}
