using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour, IPointerClickHandler
{
    private Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
        EventBus.Subscribe(EventType.IDLE, ToggleRaycastTarget);
        EventBus.Subscribe(EventType.RESTART, ResetInputInfo);
    }

    private void ResetInputInfo()
    {
        image.raycastTarget = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ToggleRaycastTarget();
        EventBus.Publish(EventType.FOWARD);
    }

    private void ToggleRaycastTarget()
    {
        image.raycastTarget = !image.raycastTarget;
    }
}
