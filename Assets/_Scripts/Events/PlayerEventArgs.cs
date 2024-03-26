using System;

public enum PlayerEventType
{
    Flap,
    Shit,
    Death
}
public class PlayerEventArgs : EventArgs
{
    public PlayerEventType EventType;

    public PlayerEventArgs(PlayerEventType eventType)
    {
        EventType = eventType;
    }
}