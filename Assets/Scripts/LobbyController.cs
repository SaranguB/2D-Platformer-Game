using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button playButton;
    public Button buttonQuit;

    private void Awake()
    {
        playButton.onClick.AddListener(PlayButton);
        buttonQuit.onClick.AddListener(QuitGame);

    }

    private void QuitGame()
    {
        Application.Quit();
    }
    private void PlayButton()
    {
        SceneManager.LoadScene(1);
    }
}
