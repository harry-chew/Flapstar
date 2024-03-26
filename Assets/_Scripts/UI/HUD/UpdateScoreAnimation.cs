using DG.Tweening;
using System;
using TMPro;
using UnityEngine;

public class UpdateScoreAnimation : MonoBehaviour
{
    public Color startingColor;
    public Color updatingColor;

    private TextMeshProUGUI scoreText;
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        GameEvents.ScoreEvent += OnScoreEvent;
    }

    private void OnDisable()
    {
        GameEvents.ScoreEvent -= OnScoreEvent;
    }

    private void OnScoreEvent(object sender, ScoreEventArgs e)
    {
        if (e.EventType == ScoreEventType.Add)
        {
            AnimateText();
        }
    }

    private void AnimateText()
    {
        Sequence anim = DOTween.Sequence(scoreText);
        anim.Append(DOTween.To(() => scoreText.color, x => scoreText.color = x, updatingColor, 0.1f)).SetEase(Ease.InOutBounce);
        anim.Join(scoreText.transform.DOScale(1.1f, 0.1f)).SetEase(Ease.InOutBounce);
        anim.Append(DOTween.To(() => scoreText.color, x => scoreText.color = x, startingColor, 0.1f)).SetEase(Ease.InOutBounce);
        anim.Join(scoreText.transform.DOScale(1.0f, 0.1f)).SetEase(Ease.InOutBounce);
        anim.Play();
    }
}
