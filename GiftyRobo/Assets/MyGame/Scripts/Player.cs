using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const float speed = 2f;
    private int LRMovement = 0;
    private int BTMovement = 0;

    [SerializeField] private InputObjectState joystickLR;
    [SerializeField] private InputObjectState joystickBT;
    [SerializeField] private InputObjectState buttonA;

    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void UpdateInputState()
    {
        InputObjectState.StateTypes stateLR = joystickLR.state;
        InputObjectState.StateTypes stateBT = joystickBT.state;
        LRMovement = stateLR switch
        {
            InputObjectState.StateTypes.Neutral => 0,
            InputObjectState.StateTypes.Positive => 1,
            InputObjectState.StateTypes.Negative => -1,
            _ => 0
        };
        BTMovement = stateBT switch
        {
            InputObjectState.StateTypes.Neutral => 0,
            InputObjectState.StateTypes.Positive => 1,
            InputObjectState.StateTypes.Negative => -1,
            _ => 0
        };
    }

    // Calculates and returns the current new Vector3 position of the player based on input.
    private Vector2 GetUpdatedCoordinates()
    {
        Vector3 coords = transform.position;
        coords.x += LRMovement * speed * Time.deltaTime;
        coords.y += BTMovement * speed * Time.deltaTime;
        return new Vector2(coords.x, coords.y);
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateInputState(); // Update LR- and BTMovement variables so we know what direction player wants to move.
        rb.MovePosition(GetUpdatedCoordinates()); // Move player based on direction and input
    }
}