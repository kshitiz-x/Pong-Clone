using UnityEngine;

public class BallController : MonoBehaviour
{
    public float startSpeed = 8f;
    public float speedIncrease = 0.5f;
    public float maxSpeed = 20f;

    private Rigidbody2D rb;
    private float currentSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ResetBall();
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

        Vector2 dir = new Vector2(x, y).normalized;

        rb.linearVelocity = dir * currentSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Paddle"))
            return;

        currentSpeed = Mathf.Min(currentSpeed + speedIncrease, maxSpeed);

        float paddleY = collision.transform.position.y;
        float hitY = transform.position.y;

        float offset = (hitY - paddleY) / 1f;

        Vector2 dir;

        if (transform.position.x < 0)
            dir = new Vector2(1f, offset);
        else
            dir = new Vector2(-1f, offset);

        dir.Normalize();

        rb.linearVelocity = dir * currentSpeed;
    }
}