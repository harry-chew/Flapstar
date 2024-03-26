using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float speed;
    private Vector3 moveDirection = Vector3.left;

    public void Init(float speed)
    {
        this.speed = speed;
    }

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * moveDirection);
    }
}