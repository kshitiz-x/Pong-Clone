using UnityEngine;

public class Goal : MonoBehaviour
{
    [Header("Goal Settings")]
    public bool leftGoal;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip scoreSound;

    private GameManager gameManager;
    private BallController ball;

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        ball = FindFirstObjectByType<BallController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Ball"))
            return;

        // Play score sound
        if (audioSource != null && scoreSound != null)
        {
            audioSource.PlayOneShot(scoreSound);
        }

        // Update score
        if (leftGoal)
            gameManager.RightPlayerScored();
        else
            gameManager.LeftPlayerScored();

        // Reset ball if game isn't over
        if (ball != null)
        {
            ball.ResetBall();
        }
    }
}