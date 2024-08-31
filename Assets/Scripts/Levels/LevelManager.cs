using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public string[] Levels;
    private static LevelManager instance;

    public static LevelManager Instance { get { return instance; } }


    private void Start()
    {
        if (GetLevelStatus(Levels[0]) == LevelStatus.LOCKED) ;
        {
            SetLevelStatus(Levels[0], LevelStatus.UNLOCKED);
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
    public LevelStatus GetLevelStatus(string Level)
    {
        LevelStatus levelStatus = (LevelStatus)PlayerPrefs.GetInt(Level, 0);
        return levelStatus;
    }

    public void SetLevelStatus(string Level, LevelStatus LevelStatus)
    {

        PlayerPrefs.SetInt(Level, (int)LevelStatus);
    }
}
