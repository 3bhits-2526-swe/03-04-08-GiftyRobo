using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickLRRotation : MonoBehaviour,
    IPointerDownHandler, IPointerUpHandler
{
    private Vector3 idleRotation;
    private const float TURN_ANGLE = 50f;
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
            newRotation.y = idleRotation.y - TURN_ANGLE;
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            newRotation.y = idleRotation.y + TURN_ANGLE;
        }
        transform.eulerAngles = newRotation;
    }
}