using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public string[] Levels;
    private static LevelManager instance;
    
    public static LevelManager Instance { get { return instance; } }


    private void Start()
    {
        if (GetLevelStatus(Levels[0]) == LevelStatus.LOCKED || GetLevelStatus(Levels[0]) == LevelStatus.COMPLETED)
        {
            SetLevelStatus(Levels[0], LevelStatus.UNLOCKED);
        }
        for (int i = 1; i < Levels.Length; i++)
        {
            if (GetLevelStatus(Levels[i]) == LevelStatus.UNLOCKED || GetLevelStatus(Levels[i]) == LevelStatus.COMPLETED)
            {
                SetLevelStatus(Levels[i], LevelStatus.LOCKED);

            }
        }

    }

   
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void MarkCurrentLevelComplete()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SetLevelStatus(currentScene.name, LevelStatus.COMPLETED);
        /*
                int nextSceneIndex = currentScene.buildIndex + 1;
                Scene nextScene = SceneManager.GetSceneByBuildIndex(nextSceneIndex);
                SetLevelStatus(nextScene.name, LevelStatus.UNLOCKED);*/
        int currentSceneIndex = Array.FindIndex(Levels, level => level == currentScene.name);
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex < Levels.Length)
        {

            SetLevelStatus(Levels[nextSceneIndex], LevelStatus.UNLOCKED);
        }

    }
    public LevelStatus GetLevelStatus(string level)
    {
        LevelStatus levelStatus = (LevelStatus)PlayerPrefs.GetInt(level, 0);
        return levelStatus;
    }

    public void SetLevelStatus(string level, LevelStatus LevelStatus)
    {

        PlayerPrefs.SetInt(level, (int)LevelStatus);
    }
}
