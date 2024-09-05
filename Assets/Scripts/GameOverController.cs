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
        SoundManager.Instance.PlayMusic(Sounds.MUSIC);

    }
    public void PlayerDied()
    {
        SoundManager.Instance.PlayMusic(Sounds.PLAYER_DEATH);
       gameObject.SetActive(true);
    }

    private void ReloadLevel()
    {
        int currentSceneIntex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIntex);
        SoundManager.Instance.PlayMusic(Sounds.MUSIC);
    }
}
