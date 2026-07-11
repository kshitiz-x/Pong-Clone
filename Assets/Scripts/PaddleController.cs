using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 8f;
    public KeyCode upKey;
    public KeyCode downKey;

    void Update()
    {
        float move = 0f;

        if (Input.GetKey(upKey))
            move = 1f;

        if (Input.GetKey(downKey))
            move = -1f;

        Vector3 pos = transform.position;

        pos.y += move * speed * Time.deltaTime;

        // Clamp so the paddle never leaves the play area
        pos.y = Mathf.Clamp(pos.y, -4f, 4f);

        transform.position = pos;
    }
}