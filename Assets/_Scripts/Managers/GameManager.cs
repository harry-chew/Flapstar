using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private float score;
    public float scoreMultiplier;
    private float currentScoreMultiplier;
    public bool isGameRunning;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } 
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PauseGame();
        currentScoreMultiplier = scoreMultiplier;
    }

    private void Subscribe()
    {
        GameEvents.ScoreEvent += OnScoreEvent;
        GameEvents.GameEvent += OnGameEvent;
        GameEvents.ObstacleEvent += OnObstacleEvent;
    }

    private void UnSubscribe()
    {
        GameEvents.ScoreEvent -= OnScoreEvent;
        GameEvents.GameEvent -= OnGameEvent;
        GameEvents.ObstacleEvent -= OnObstacleEvent;
    } 

    private void OnGameEvent(object sender, GameEventArgs e)
    {
        if (e.EventType == GameEventType.Start)
        {
            StartGame();
        }
        if (e.EventType == GameEventType.End)
        {
            SaveHiScore();
            EndGame();
            score = 0;
        }
        if (e.EventType == GameEventType.Restart)
        {
            RestartGame();
        }
    }

    private void SaveHiScore()
    { 
        if (PlayerPrefs.HasKey("hiscore"))
        {
            if (PlayerPrefs.GetFloat("hiscore") < score)
            {
                PlayerPrefs.SetFloat("hiscore", score);
            }
        }
        else
        {
            PlayerPrefs.SetFloat("hiscore", score);
        }
        PlayerPrefs.Save();
    }

    public float GetHiScore()
    {
        return PlayerPrefs.GetFloat("hiscore");
    }

    private void OnScoreEvent(object sender, ScoreEventArgs e)
    {
        if (e.EventType == ScoreEventType.Add)
        {
            AddScore(e.Score);
        }

        if (e.EventType == ScoreEventType.Remove)
        {
            AddScore(-e.Score);
        }
    }

    private void OnObstacleEvent(object sender, ObstacleEventArgs e)
    {
        if (e.EventType == ObstacleEventType.PlayerPass)
        {
            ApplyScoreMultiplier();
        }
    }

    public float GetScore()
    {
        return score;
    }

    public float GetScoreMultiplier()
    {
        return currentScoreMultiplier;
    }

    public void AddScore(float scoreToAdd)
    {
        score += scoreToAdd;
    }

    public void ApplyScoreMultiplier()
    {
        score *= currentScoreMultiplier;
    }

    public void StartGame()
    {
        Subscribe();
        Time.timeScale = 1.0f;
        isGameRunning = true;
        GameEvents.FireSpawnObstacleEvent();
    }

    public void EndGame()
    {
        UnSubscribe();
        isGameRunning = false;
    }

    public void PauseGame()
    {
        isGameRunning = false;
        Time.timeScale = 0.0f;
    }

    public void RestartGame()
    {
        Subscribe();
        Time.timeScale = 1.0f;
        isGameRunning = true;
        currentScoreMultiplier = scoreMultiplier;
        GameEvents.FireSpawnObstacleEvent();
    }
}