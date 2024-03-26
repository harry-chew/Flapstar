using System;

public static class GameEvents
{
    public static EventHandler<GameEventArgs> GameEvent;
    public static EventHandler<ScoreEventArgs> ScoreEvent;
    public static EventHandler<ObstacleEventArgs> ObstacleEvent;
    public static EventHandler<AudioEventArgs> AudioEvent;
    public static EventHandler<PlayerEventArgs> PlayerEvent;

    public static void FireStartGameEvent()
    {
        GameEventArgs args = new GameEventArgs(GameEventType.Start);
        GameEvent?.Invoke(null, args);
    }

    public static void FireRestartGameEvent()
    {
        GameEventArgs args = new GameEventArgs(GameEventType.Restart);
        GameEvent?.Invoke(null, args);
    }

    public static void FireEndGameEvent()
    {
        GameEventArgs args = new GameEventArgs(GameEventType.End);
        GameEvent?.Invoke(null, args);
    }

    public static void FireAddScoreEvent(float score)
    {
        ScoreEventArgs args = new ScoreEventArgs(ScoreEventType.Add, score);
        ScoreEvent?.Invoke(null, args);
    }

    public static void FireSpawnObstacleEvent()
    {
        ObstacleEventArgs args = new ObstacleEventArgs(ObstacleEventType.TriggerSpawn);
        ObstacleEvent?.Invoke(null, args);
    }

    public static void FirePassObstacleEvent()
    {
        ObstacleEventArgs args = new ObstacleEventArgs(ObstacleEventType.PlayerPass);
        ObstacleEvent?.Invoke(null, args);
    }

    public static void FireMenuHoverAudioEvent()
    {
        AudioEventArgs args = new AudioEventArgs(AudioEventType.MenuHover);
        AudioEvent?.Invoke(null, args);
    }

    public static void FireMenuClickAudioEvent()
    {
        AudioEventArgs args = new AudioEventArgs(AudioEventType.MenuClick);
        AudioEvent?.Invoke(null, args);
    }

    public static void FireFlapPlayerEvent()
    {
        PlayerEventArgs args = new PlayerEventArgs(PlayerEventType.Flap);
        PlayerEvent?.Invoke(null, args);
    }

    public static void FireShitPlayerEvent()
    {
        PlayerEventArgs args = new PlayerEventArgs(PlayerEventType.Shit);
        PlayerEvent?.Invoke(null, args);
    }

    public static void FireDeathPlayerEvent() 
    {
        PlayerEventArgs args = new PlayerEventArgs(PlayerEventType.Death);
        PlayerEvent?.Invoke(null, args);
    }
}