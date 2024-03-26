using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float flapForce;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameEvents.GameEvent += OnGameEvent;
    }

    private void OnDestroy()
    {
        GameEvents.GameEvent -= OnGameEvent;
    }

    private void OnGameEvent(object sender, GameEventArgs e)
    {
        if (e.EventType == GameEventType.End)
        {
            transform.position = Vector2.zero;
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0.0f;
        }

        if (e.EventType == GameEventType.Restart)
        {
            rb.gravityScale = 1.0f;
            rb.velocity = Vector2.zero;
        }
    }

    public void Update()
    {
        if (GameManager.Instance.isGameRunning)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Flap();
            }
        }
    }

    public void Flap()
    {
        rb.AddRelativeForce(Vector2.up * flapForce);
        GameEvents.FireFlapPlayerEvent();
    }
}