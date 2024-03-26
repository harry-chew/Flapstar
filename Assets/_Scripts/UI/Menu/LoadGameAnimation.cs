using DG.Tweening;
using UnityEngine;

public class LoadGameAnimation : MonoBehaviour
{
    public Transform topBlinker;
    public Transform bottomBlinker;

    public float topStart;
    public float bottomStart;

    public void SetupMenuPositions()
    {
        topBlinker.localPosition = new Vector3(topBlinker.localPosition.x, topStart, topBlinker.localPosition.z);
        bottomBlinker.localPosition = new Vector3(bottomBlinker.localPosition.x, bottomStart, bottomBlinker.localPosition.z);
    }

    public void SetupGamePositions()
    {
        topBlinker.localPosition = new Vector3(topBlinker.localPosition.x, 0f, topBlinker.localPosition.z);
        bottomBlinker.localPosition = new Vector3(bottomBlinker.localPosition.x, 0f, bottomBlinker.localPosition.z);
    }

    public void Blink()
    {
        Sequence anim = DOTween.Sequence();
        anim.Join(topBlinker.DOLocalMoveY(0, 0.5f));
        anim.Join(bottomBlinker.DOLocalMoveY(0, 0.5f));
        //AudioManager.Instance.PlayFadeSFX();
        anim.Play().WaitForCompletion();
        DOTween.Kill(anim);
    }

    public void UnBlink()
    {
        Sequence anim = DOTween.Sequence();
        anim.Join(topBlinker.DOLocalMoveY(topStart, 0.5f));
        anim.Join(bottomBlinker.DOLocalMoveY(bottomStart, 0.5f));
        anim.Play().WaitForCompletion();
        DOTween.Kill(anim);
    }
}