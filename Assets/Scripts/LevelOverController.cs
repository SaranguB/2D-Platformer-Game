using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            int currentSceneIntex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIntex);
        }
    }
}
