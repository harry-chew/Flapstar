using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonTween : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Sequence hoverAnimation;
    public void OnPointerEnter(PointerEventData eventData)
    {
        hoverAnimation = DOTween.Sequence(gameObject);
        hoverAnimation.Join(transform.DOShakePosition(0.25f, 3, 10, 10, false, true).SetEase(Ease.Flash));
        hoverAnimation.Join(transform.DOScale(1.1f, 0.25f));
        hoverAnimation.Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        DOTween.Kill(hoverAnimation);
        transform.DOScale(1.0f, 0.1f);
    }
}