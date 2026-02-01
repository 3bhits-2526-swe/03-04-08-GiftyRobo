using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const float speed = 5f;
    private Rigidbody2D rb;

    private int lrDir = 0; // -1, 0, 1
    private int btDir = 0; // -1, 0, 1

    public static Action<Collider2D> OnTouchGift;
    public static Action<Collider2D> OnTouchCat;

    [SerializeField] private GameState gameState;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        JoystickLRRotation.OnJoystickLRChange += SetLRDirection;
        JoystickBTRotation.OnJoystickBTChange += SetBTDirection;
    }

    private void OnDisable()
    {
        JoystickLRRotation.OnJoystickLRChange -= SetLRDirection;
        JoystickBTRotation.OnJoystickBTChange -= SetBTDirection;
    }

    private void SetLRDirection(int direction)
    {
        lrDir = direction;
    }

    private void SetBTDirection(int direction)
    {
        btDir = direction;
    }

    private void FixedUpdate()
    {
        Vector2 move = new Vector2(lrDir, btDir) * (speed * Time.fixedDeltaTime);
        rb.MovePosition(rb.position + move);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        bool isGift = other.CompareTag("Gift");
        bool isCat = other.CompareTag("Cat");
        bool giftEquipped = gameState.giftState == GameState.GiftState.Equipped;
        
        if (isGift && !giftEquipped)
        {
            OnTouchGift?.Invoke(other);
        }

        if (isCat && giftEquipped)
        {
            OnTouchCat?.Invoke(other);
        }
    }
}