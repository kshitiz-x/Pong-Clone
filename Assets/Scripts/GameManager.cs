using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource musicSource;
    public AudioClip bgMusic;

    public AudioSource winSource;
    public AudioClip winSound;

    [Header("UI")]
    public TextMeshProUGUI leftScoreText;
    public TextMeshProUGUI rightScoreText;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI countdownText;

    [Header("Game")]
    public BallController ball;

    private int leftScore = 0;
    private int rightScore = 0;
    private bool gameOver = false;

   void Start()
{
    UpdateScore();

    if (winText != null)
        winText.gameObject.SetActive(false);

    if (countdownText != null)
        countdownText.gameObject.SetActive(false);

    // Start background music
    if (musicSource != null && bgMusic != null)
    {
        musicSource.clip = bgMusic;
        musicSource.loop = true;
        musicSource.Play();
    }

    // Start countdown
    StartCoroutine(StartRound());
}

    void Update()
    {
        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    IEnumerator StartRound()
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

        if (ball != null)
            ball.ResetBall();
    }

    public void LeftPlayerScored()
    {
        if (gameOver)
            return;

        leftScore++;
        UpdateScore();
        CheckWinner();
    }

    public void RightPlayerScored()
    {
        if (gameOver)
            return;

        rightScore++;
        UpdateScore();
        CheckWinner();
    }

    void UpdateScore()
    {
        if (leftScoreText != null)
            leftScoreText.text = leftScore.ToString();

        if (rightScoreText != null)
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

        if (ball != null)
            ball.StopBall();

        if (winText != null)
        {
            winText.gameObject.SetActive(true);
            winText.text = message + "\nPress R to Restart";
        }

        // Stop background music
        if (musicSource != null)
            musicSource.Stop();

        // Play win sound
        if (winSource != null && winSound != null)
            winSource.PlayOneShot(winSound);
    }
}