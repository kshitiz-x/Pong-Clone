using UnityEngine;

public class BallController : MonoBehaviour
{
    public float startSpeed = 8f;
    public float speedIncrease = 0.5f;
    public float maxSpeed = 20f;

    private float currentSpeed;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = startSpeed;

        LaunchBall();
    }

    void LaunchBall()
    {
        Vector2 direction = new Vector2(
            Random.Range(0, 2) == 0 ? -1 : 1,
            Random.Range(-0.5f, 0.5f)
        ).normalized;

        rb.linearVelocity = direction * currentSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            currentSpeed = Mathf.Min(currentSpeed + speedIncrease, maxSpeed);

            Vector2 direction = rb.linearVelocity.normalized;

            rb.linearVelocity = direction * currentSpeed;
        }
    }
}