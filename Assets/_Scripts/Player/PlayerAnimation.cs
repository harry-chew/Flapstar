using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Transform body;
    public Transform arm;
    public Transform eye;
    private Vector3 eyeScale;

    private Rigidbody2D rb;
    private Vector2 velocity;

    private float angle;
    public float minAngle, maxAngle, minVelocity, maxVelocity;

    private void Start()
    {
        GameEvents.PlayerEvent += OnPlayerEvent;
        GameEvents.ObstacleEvent += OnObstacleEvent;

        eyeScale = eye.localScale;
        rb = GetComponent<Rigidbody2D>();
        DOTween.SetTweensCapacity(1500, 50);
    }

    private void OnDisable()
    {
        GameEvents.PlayerEvent -= OnPlayerEvent;
        GameEvents.ObstacleEvent -= OnObstacleEvent;
    }

    private void OnObstacleEvent(object sender, ObstacleEventArgs e)
    {
        if (e.EventType == ObstacleEventType.PlayerPass)
        {
            Blink();
        }
    }

    private void OnPlayerEvent(object sender, PlayerEventArgs e)
    {
        if (e.EventType == PlayerEventType.Flap)
        {
            FlapWings();
        }
    }


    private void Update()
    {
        velocity = rb.velocity;
        angle = Map(velocity.y, minVelocity, maxVelocity, minAngle, maxAngle);
        body.DOLocalRotate(new Vector3(0, 0, angle), 0.5f);
    }

    private void FlapWings()
    {
        Sequence anim = DOTween.Sequence(arm);
        if (DOTween.IsTweening(arm))
        {
            DOTween.Kill(anim);
        }
        anim.Join(arm.DOLocalRotate(new Vector3(0, 0, 30), 0.1f));
        anim.Append(arm.DOLocalRotate(new Vector3(0, 0, -30), 0.25f));
        anim.Play();
    }

    private void Blink()
    {
        Sequence anim = DOTween.Sequence(eye);
        if (DOTween.IsTweening(eye))
        {
            DOTween.Kill(anim);
        }
        anim.Join(eye.DOScaleY(0.0f, 0.1f));
        anim.Append(eye.DOScaleY(eyeScale.y, 0.1f));
        anim.Play();
    }

    private float Map(float velocity, float in_min, float in_max, float out_min, float out_max)
    {
        return (velocity - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
    }
}