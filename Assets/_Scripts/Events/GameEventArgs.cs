using System;

public enum GameEventType
{
    Start,
    Restart,
    End
}

public class GameEventArgs : EventArgs
{
    public GameEventType EventType;

    public GameEventArgs(GameEventType eventType)
    {
        EventType = eventType;
    }
}