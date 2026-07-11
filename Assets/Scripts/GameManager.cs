using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI leftScoreText;
    public TextMeshProUGUI rightScoreText;

    private int leftScore = 0;
    private int rightScore = 0;

    void Start()
    {
        UpdateScore();
    }

    public void LeftPlayerScored()
    {
        leftScore++;
        UpdateScore();
    }

    public void RightPlayerScored()
    {
        rightScore++;
        UpdateScore();
    }

    void UpdateScore()
    {
        leftScoreText.text = leftScore.ToString();
        rightScoreText.text = rightScore.ToString();
    }
}