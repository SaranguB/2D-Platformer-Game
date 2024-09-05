using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    private Button button;

    public string levelName;
    private void Awake()
    {
 
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

  
    private void OnClick()
    {
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(levelName);

        switch (levelStatus)
        {
            case LevelStatus.LOCKED:

                break;

            case LevelStatus.UNLOCKED:
               // Debug.Log("Unlocked");

                SoundManager.Instance.Play(Sounds.BUTTON_CLICK);
                SceneManager.LoadScene(levelName);
                break;

            case LevelStatus.COMPLETED:
                //Debug.Log("Completed");
                SceneManager.LoadScene(levelName);
                break;
        }

    }
}
