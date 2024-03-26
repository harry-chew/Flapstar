using System;

public enum ScoreEventType
{
    Add,
    Remove
}

public class ScoreEventArgs : EventArgs
{
    public float Score;
    public ScoreEventType EventType;

    public ScoreEventArgs(ScoreEventType eventType, float score)
    {
        EventType = eventType;
        Score = score;
    }
}