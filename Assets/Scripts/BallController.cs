using UnityEngine;

public class BallController : MonoBehaviour
{
    [Header("Ball Settings")]
    public float startSpeed = 8f;
    public float speedIncrease = 0.5f;
    public float maxSpeed = 20f;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip paddleHitSound;
    public AudioClip wallHitSound;

    private Rigidbody2D rb;
    private float currentSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.zero;
    }

    public void ResetBall()
    {
        transform.position = Vector2.zero;

        currentSpeed = startSpeed;

        Launch();
    }

    void Launch()
    {
        float x = Random.value < 0.5f ? -1f : 1f;
        float y = Random.Range(-0.7f, 0.7f);

        Vector2 direction = new Vector2(x, y).normalized;

        rb.linearVelocity = direction * currentSpeed;
    }

    public void StopBall()
    {
        rb.linearVelocity = Vector2.zero;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            if (audioSource != null && paddleHitSound != null)
            {
                audioSource.PlayOneShot(paddleHitSound);
            }

            currentSpeed = Mathf.Min(currentSpeed + speedIncrease, maxSpeed);

            float paddleY = collision.transform.position.y;
            float hitY = transform.position.y;

            float offset = hitY - paddleY;

            Vector2 direction;

            if (transform.position.x < 0)
                direction = new Vector2(1f, offset);
            else
                direction = new Vector2(-1f, offset);

            direction.Normalize();

            rb.linearVelocity = direction * currentSpeed;
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            if (audioSource != null && wallHitSound != null)
            {
                audioSource.PlayOneShot(wallHitSound);
            }
        }
    }
}