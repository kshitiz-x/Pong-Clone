using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    [Header("References")]
    public Transform ball;

    private Rigidbody2D rb;

    private float moveSpeed;
    private float reactionTime;
    private float missChance;

    private float targetY;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        switch (GameSettings.difficulty)
        {
            case Difficulty.Easy:
                moveSpeed = 5f;
                reactionTime = 0.35f;
                missChance = 0.30f;
                break;

            case Difficulty.Medium:
                moveSpeed = 8f;
                reactionTime = 0.18f;
                missChance = 0.10f;
                break;

            case Difficulty.Hard:
                moveSpeed = 12f;
                reactionTime = 0.05f;
                missChance = 0f;
                break;
        }
        Debug.Log("Current Difficulty: " + GameSettings.difficulty);
        Debug.Log("AI Speed: " + moveSpeed);

        StartCoroutine(UpdateTarget());
    }

    IEnumerator UpdateTarget()
    {
        while (true)
        {
            if (ball != null)
            {
                targetY = ball.position.y;

                // AI sometimes makes mistakes
                if (Random.value < missChance)
                {
                    targetY += Random.Range(-2f, 2f);
                }
            }

            yield return new WaitForSeconds(reactionTime);
        }
    }

    void FixedUpdate()
    {
        if (ball == null)
            return;

        float direction = 0f;

        if (targetY > transform.position.y + 0.2f)
            direction = 1f;
        else if (targetY < transform.position.y - 0.2f)
            direction = -1f;

        rb.linearVelocity = new Vector2(0f, direction * moveSpeed);
    }
}