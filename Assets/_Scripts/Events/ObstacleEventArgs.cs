using System;

public enum ObstacleEventType
{
    TriggerSpawn,
    PlayerPass
}

public class ObstacleEventArgs : EventArgs
{
    public ObstacleEventType EventType;

    public ObstacleEventArgs(ObstacleEventType eventType)
    {
        EventType = eventType;
    }
}