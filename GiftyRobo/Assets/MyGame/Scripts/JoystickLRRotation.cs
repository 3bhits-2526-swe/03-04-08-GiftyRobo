using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class JoystickLRRotation : MonoBehaviour,
    IPointerDownHandler, IPointerUpHandler
{
    private Vector3 idleRotation;
    private const float TURN_ANGLE = 50f;
    [SerializeField] private InputObjectState joystickLR;
    public static Action<int> OnJoystickLRChange;

    void Start()
    {
        idleRotation = transform.localEulerAngles;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localEulerAngles = idleRotation;
        joystickLR.state = InputObjectState.StateTypes.Neutral;

        OnJoystickLRChange?.Invoke((int)joystickLR.state); // IMPORTANT
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Vector3 newRotation = idleRotation;
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            newRotation.y = idleRotation.y - TURN_ANGLE;
            joystickLR.state = InputObjectState.StateTypes.Positive;
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            newRotation.y = idleRotation.y + TURN_ANGLE;
            joystickLR.state = InputObjectState.StateTypes.Negative;
        }
        OnJoystickLRChange?.Invoke((int)joystickLR.state); // notify
        transform.eulerAngles = newRotation;
    }
}