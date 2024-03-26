using UnityEngine;

public class Shit : MonoBehaviour
{
    private Rigidbody2D rb;
    public void Init(float speed)
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * speed;
    }
}