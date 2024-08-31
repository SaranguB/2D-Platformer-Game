
using UnityEngine;


public class LevelOverController : MonoBehaviour
{
    public LevelCompletedController completed;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            LevelManager.Instance.MarkCurrentLevelComplete();
            completed.PlayerWon();
        }
    }
}
