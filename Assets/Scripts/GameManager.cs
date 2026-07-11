using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI leftScoreText;
    public TextMeshProUGUI rightScoreText;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI countdownText;

    public BallController ball;

    private int leftScore = 0;
    private int rightScore = 0;

    private bool gameOver = false;

    void Start()
    {
        UpdateScore();

        winText.gameObject.SetActive(false);
        countdownText.gameObject.SetActive(false);

        StartCoroutine(GameStartCountdown());
    }

    void Update()
    {
        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    IEnumerator GameStartCountdown()
    {
        countdownText.gameObject.SetActive(true);

        countdownText.text = "3";
        yield return new WaitForSeconds(1f);

        countdownText.text = "2";
        yield return new WaitForSeconds(1f);

        countdownText.text = "1";
        yield return new WaitForSeconds(1f);

        countdownText.text = "GO!";
        yield return new WaitForSeconds(0.5f);

        countdownText.gameObject.SetActive(false);

        ball.ResetBall();
    }

    public void LeftPlayerScored()
    {
        if (gameOver)
            return;

        leftScore++;
        UpdateScore();

        CheckWinner();

        if (!gameOver)
            ball.ResetBall();
    }

    public void RightPlayerScored()
    {
        if (gameOver)
            return;

        rightScore++;
        UpdateScore();

        CheckWinner();

        if (!gameOver)
            ball.ResetBall();
    }

    void UpdateScore()
    {
        leftScoreText.text = leftScore.ToString();
        rightScoreText.text = rightScore.ToString();
    }

    void CheckWinner()
    {
        if (leftScore >= 10)
        {
            EndGame("Player 1 Wins!");
        }
        else if (rightScore >= 10)
        {
            EndGame("Player 2 Wins!");
        }
    }

    void EndGame(string message)
    {
        gameOver = true;

        ball.StopBall();

        winText.gameObject.SetActive(true);
        winText.text = message + "\nPress R to Restart";
    }
}