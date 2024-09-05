using UnityEngine;
using TMPro;


public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    private int score = 0;
    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        RefreshUI();
    }
    public void IncreaseScore(int increament)
    {
        score += increament;
        RefreshUI();
    }

    private void RefreshUI()
    {
        scoreText.text = "score :" + score; 
    }
}
