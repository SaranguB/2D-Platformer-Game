using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelCompletedController : MonoBehaviour
{

    public Button ButtonNextLevel;
    public Button ButtonMenu;
    

    private void Awake()
    {
        ButtonNextLevel.onClick.AddListener(NextLevel);
        ButtonMenu.onClick.AddListener(Menu);
    }
    private void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    private void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayerWon()
    {
        gameObject.SetActive(true);
    }

}
