using System.Runtime.CompilerServices;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonAInteraction : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private InputObjectState buttonA;
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
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Vector3 newPos = transform.position;
        newPos.y += DELTA_Y;
        transform.position = newPos;
        buttonA.state = InputObjectState.StateTypes.Neutral;
    }
}