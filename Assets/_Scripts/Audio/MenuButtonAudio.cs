using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButtonAudio : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        GameEvents.FireMenuHoverAudioEvent();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameEvents.FireMenuClickAudioEvent();
    }
}