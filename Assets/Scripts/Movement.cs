using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
public class Movement : MonoBehaviour
{
    public float moveSpeed = 8;
    public float jumpPower = 10;
    public Transform groundCheck;
    public float groundChecker = 0.2f;
    public LayerMask groundLayer;
    private Rigidbody2D rb;
    private float moveInput;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Input();
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Input()
    {
        moveInput = 0;
        Keyboard kb = Keyboard.current;
        if (kb.aKey.isPressed)
        {
            moveInput = -1;
            transform.localScale = new Vector2(-1.516f,1.5f);

        }
        if (kb.dKey.isPressed) 
        {
            moveInput = 1;
            transform.localScale = new Vector2(1.516f,1.5f);
        }
        if (kb.spaceKey.wasPressedThisFrame) Jump();
    }
    private void Move()
    {
        rb.linearVelocityX = moveInput * moveSpeed;
    }

    private void Jump()
    {
        if (IsGrounded())
        {
            rb.linearVelocityY = jumpPower;
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundChecker, groundLayer);
    }
    
}
