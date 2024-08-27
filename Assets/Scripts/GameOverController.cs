using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button buttonRestart;
    public Button buttonMenu;

    private void Awake()
    {
        buttonRestart.onClick.AddListener(ReloadLevel);
        buttonMenu.onClick.AddListener(LoadMenu);
    }
    private void LoadMenu()
    {
        SceneManager.LoadScene(0);

    }
    public void PlayerDied()
    {
       gameObject.SetActive(true);
    }

    private void ReloadLevel()
    {
        int currentSceneIntex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIntex);
    }
}
