using TMPro;
using UnityEngine;

public class HiScoreUI : MonoBehaviour
{
    private TextMeshProUGUI hiScore;
    private void Start()
    {
        hiScore = GetComponent<TextMeshProUGUI>();
        UpdateHiScore();
        GameEvents.GameEvent += OnGameEvent;
    }

    private void OnDestroy() 
    {
        GameEvents.GameEvent -= OnGameEvent;
    }
    private void UpdateHiScore()
    {
        hiScore.text = GameManager.Instance.GetHiScore().ToString("F0");
    }

    private void OnGameEvent(object sender, GameEventArgs e)
    {
        if (e.EventType == GameEventType.End)
        {
            UpdateHiScore();
        }
    }
}