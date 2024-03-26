using UnityEngine;

public class ObstacleTrigger : MonoBehaviour
{
    private bool hasTriggered;
    private void Start()
    {
        hasTriggered = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerCollisions>(out var player) && !hasTriggered)
        {
            hasTriggered = true;
            GameEvents.FireSpawnObstacleEvent();
            GameEvents.FireAddScoreEvent(1f);
            GameEvents.FirePassObstacleEvent();
        }
    }
}