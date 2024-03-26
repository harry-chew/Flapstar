using DG.Tweening;
using System;
using TMPro;
using UnityEngine;
public class ClickToStartUI : MonoBehaviour
{
    private bool hasClicked;
    private CanvasGroup canvasGroup;
    public TextMeshProUGUI clickToStartText;
    public TextMeshProUGUI clickToStartShadow;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        hasClicked = false;
        GameEvents.GameEvent += OnGameEvent;
    }

    private void OnGameEvent(object sender, GameEventArgs e)
    {
        if (e.EventType == GameEventType.End)
        {
            ResetUI();
        }
    }

    public void OnClickToStart()
    {
        if (!hasClicked)
        {
            hasClicked = true;
            GameEvents.FireRestartGameEvent();
            GameManager.Instance.StartGame();
            DOTween.To(() => canvasGroup.alpha, x => canvasGroup.alpha = x, 0.0f, 0.5f);
        }
    }

    public void ResetUI()
    {
        clickToStartShadow.text = "Click to RESTART";
        clickToStartText.text = "Click to RESTART";
        Sequence anim = DOTween.Sequence();
        anim.Join(DOTween.To(() => canvasGroup.alpha, x => canvasGroup.alpha = x, 1.0f, 0.5f));
        anim.Play().SetEase(Ease.OutBack).WaitForCompletion();
        hasClicked = false;
    }
}