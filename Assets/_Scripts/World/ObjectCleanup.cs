using UnityEngine;

public class ObjectCleanup : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit");
        Destroy(collision.gameObject);
    }
}