using UnityEngine;

public class Cloud : MonoBehaviour
{
    private Rigidbody2D rb;

    public void Init(float speed)
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddRelativeForce(Vector2.left * speed);
    }
}