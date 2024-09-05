
using System.Collections.Generic;
using UnityEngine;

public class LockController : MonoBehaviour
{
    public List<GameObject> locker;


    private void Update()
    {

        for (int i = 0; i < locker.Count; i++)
        {
            if (LevelManager.Instance.GetLevelStatus(LevelManager.Instance.Levels[i]) == LevelStatus.UNLOCKED 
                || LevelManager.Instance.GetLevelStatus(LevelManager.Instance.Levels[i]) == LevelStatus.COMPLETED)
            {
                locker[i].SetActive(false);
                if (i > locker.Count)
                {
                    i = 0;
                }
            }
        }
    }
}
