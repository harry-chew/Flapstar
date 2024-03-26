using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Clips")]
    public AudioClip buttonHover;
    public AudioClip buttonClick;
    public AudioClip fade;

    [Header("Audio Sources")]
    public AudioSource menu;
    public AudioSource music;
    public AudioSource flapSFX;
    public AudioSource passSFX;
    public AudioSource deathSFX;
    public AudioSource shitSFX;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        GameEvents.AudioEvent += OnAudioEvent;
        GameEvents.PlayerEvent += OnPlayerEvent;
        GameEvents.ObstacleEvent += OnObstacleEvent;
    }

    private void OnDisable()
    {
        GameEvents.AudioEvent -= OnAudioEvent;
        GameEvents.PlayerEvent -= OnPlayerEvent;
        GameEvents.ObstacleEvent -= OnObstacleEvent;
    }

    private void OnPlayerEvent(object sender, PlayerEventArgs e)
    {
        if (e.EventType == PlayerEventType.Flap)
        {
            PlayFlapSFX();
        }

        if (e.EventType == PlayerEventType.Shit)
        {
            PlayShitSFX();
        }

        if (e.EventType == PlayerEventType.Death)
        {
            if (GameManager.Instance.isGameRunning)
                PlayDeathSFX();
        }
    }

    private void OnAudioEvent(object sender, AudioEventArgs e)
    {
        switch (e.EventType)
        {
            case AudioEventType.MenuHover:
                PlayButtonHoverSFX();
                break;
            case AudioEventType.MenuClick:
                PlayButtonClickSFX();
                break;
        }
    }

    private void OnObstacleEvent(object sender, ObstacleEventArgs e)
    {
        if (e.EventType == ObstacleEventType.PlayerPass)
        {
            if (GameManager.Instance.isGameRunning)
                PlayPassSFX();
        }
    }

    private void PlayPassSFX()
    {
        passSFX.Play();
    }

    public void PlayButtonHoverSFX()
    {
        menu.clip = buttonHover;
        menu.Play();
    }

    public void PlayButtonClickSFX()
    {
        menu.clip = buttonClick;
        menu.Play();
    }

    public void PlayFlapSFX()
    {
        flapSFX.Play();
    }

    public void PlayDeathSFX()
    {
        deathSFX.Play();
    }

    private void PlayShitSFX()
    {
        shitSFX.Play();
    }

    public void PlayFadeSFX()
    {
        menu.clip = fade;
        menu.Play();
    }
}
