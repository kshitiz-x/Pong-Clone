using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 8f;

    public KeyCode upKey;
    public KeyCode downKey;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float move = 0f;

        if (Input.GetKey(upKey))
        {
            move = 1f;
        }

        if (Input.GetKey(downKey))
        {
            move = -1f;
        }

        rb.linearVelocity = new Vector2(0f, move * speed);
    }
}