using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickBTRotation : MonoBehaviour,
    IPointerDownHandler, IPointerUpHandler
{
    private Vector3 idleRotation;
    private const float TURN_ANGLE = 30f;
    [SerializeField] private int joystickID;

    void Start()
    {
        idleRotation = transform.localEulerAngles;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localEulerAngles = idleRotation;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Vector3 newRotation = idleRotation;
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            newRotation.x = idleRotation.x - TURN_ANGLE;
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            newRotation.x = idleRotation.x + TURN_ANGLE;
        }
        transform.eulerAngles = newRotation;
    }
}