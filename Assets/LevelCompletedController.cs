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
        SoundManager.Instance.PlayMusic(Sounds.MUSIC);

    }
    private void Menu()
    {
        SceneManager.LoadScene(0);
        SoundManager.Instance.PlayMusic(Sounds.MUSIC);

    }

    public void PlayerWon()
    {
        SoundManager.Instance.PlayMusic(Sounds.PLAYER_WON);
        gameObject.SetActive(true);
    }

}
