using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool leftGoal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Ball"))
            return;

        GameManager gameManager = FindFirstObjectByType<GameManager>();

        if (leftGoal)
            gameManager.RightPlayerScored();
        else
            gameManager.LeftPlayerScored();
    }
}