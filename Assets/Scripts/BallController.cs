using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 8f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        LaunchBall();
    }

    void LaunchBall()
    {
        Vector2 direction = new Vector2(
            Random.Range(0, 2) == 0 ? -1 : 1,
            Random.Range(-0.5f, 0.5f)
        );

        direction.Normalize();

        rb.linearVelocity = direction * speed;
    }
}