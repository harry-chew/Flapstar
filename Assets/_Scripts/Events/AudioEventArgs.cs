using System;

public enum AudioEventType
{
    MenuHover,
    MenuClick,
    PlayerDeath,
    StartGame,
    EndGame,
    RestartGame
}

public class AudioEventArgs : EventArgs
{
    public AudioEventType EventType;

    public AudioEventArgs(AudioEventType eventType)
    {
        EventType = eventType;
    } 
}