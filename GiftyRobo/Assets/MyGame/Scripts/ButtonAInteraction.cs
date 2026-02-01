using System.Runtime.CompilerServices;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class ButtonAInteraction : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private InputObjectState buttonA;
    public static Action OnButtonClick;
    private const float DELTA_Y = 0.01f;
    public void OnPointerClick(PointerEventData eventData)
    {
        // ...
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Vector3 newPos = transform.position;
        newPos.y -= DELTA_Y;
        transform.position = newPos;
        buttonA.state = InputObjectState.StateTypes.Positive;
        OnButtonClick?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Vector3 newPos = transform.position;
        newPos.y += DELTA_Y;
        transform.position = newPos;
        buttonA.state = InputObjectState.StateTypes.Neutral;
    }
}