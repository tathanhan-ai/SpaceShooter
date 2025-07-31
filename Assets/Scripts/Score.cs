using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public Text scoreText;
    private int totalScore = 0;

    void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int scoreToAdd)
    {
        totalScore += scoreToAdd;
        UpdateScoreText();
    }
    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + totalScore;
        }
    }
}
