using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI leftScoreText;
    public TextMeshProUGUI rightScoreText;
    public TextMeshProUGUI winText;

    private int leftScore = 0;
    private int rightScore = 0;

    private bool gameOver = false;

    void Start()
    {
        UpdateScore();

        if (winText != null)
            winText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Restarting Game...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void LeftPlayerScored()
    {
        if (gameOver)
            return;

        leftScore++;

        Debug.Log("Left Score = " + leftScore);

        UpdateScore();
        CheckWinner();
    }

    public void RightPlayerScored()
    {
        if (gameOver)
            return;

        rightScore++;

        Debug.Log("Right Score = " + rightScore);

        UpdateScore();
        CheckWinner();
    }

    void UpdateScore()
    {
        leftScoreText.text = leftScore.ToString();
        rightScoreText.text = rightScore.ToString();
    }

    void CheckWinner()
    {
        Debug.Log($"Checking Winner: {leftScore} - {rightScore}");

        if (leftScore >= 10)
        {
            Debug.Log("PLAYER 1 WINS");
            EndGame("Player 1 Wins!");
        }
        else if (rightScore >= 10)
        {
            Debug.Log("PLAYER 2 WINS");
            EndGame("Player 2 Wins!");
        }
    }

    void EndGame(string message)
    {
        Debug.Log("EndGame() Called");

        gameOver = true;

        if (winText != null)
        {
            winText.gameObject.SetActive(true);
            winText.text = message + "\nPress R to Restart";
        }

        BallController ball = FindFirstObjectByType<BallController>();

        if (ball != null)
        {
            ball.StopBall();
            Debug.Log("Ball Stopped");
        }
        else
        {
            Debug.Log("BallController NOT FOUND");
        }
    }
}