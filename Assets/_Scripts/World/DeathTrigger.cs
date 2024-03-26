using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerCollisions>(out var player))
        {
            GameEvents.FireDeathPlayerEvent();
            GameEvents.FireEndGameEvent();
        }
    }
}