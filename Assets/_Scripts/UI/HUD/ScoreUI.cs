using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    private void Start()
    {
        GameEvents.ObstacleEvent += OnScoreEvent;
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void OnDisable()
    {
        GameEvents.ObstacleEvent -= OnScoreEvent;
    }

    private void OnScoreEvent(object sender, ObstacleEventArgs e)
    {
        scoreText.text = $"{GameManager.Instance.GetScore().ToString("F0")}";
    }
}