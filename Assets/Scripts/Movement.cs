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
        rb = GetComponent<Rigidbody2D>(); //Reference to the Rigidbody
    }
    void Update()
    {
        Input(); //Calls the Input function every frame
    }
    private void FixedUpdate()
    {
        Move(); //Calls the Move function every few milliseconds
    }

    private void Input()
    {
        moveInput = 0;
        Keyboard kb = Keyboard.current;
        if (kb.aKey.isPressed)
        {
            moveInput = -1;
            transform.localScale = new Vector2(-1.516f,1.5f); //The input functiuon sets the move Input to 0 at the start and assigns the keyboard. It will then check for an input of either A or B and set the move input based on what key is pressed
                                                              //The Vector2's you see under each if statement is a call to the rotation of the player and for some reason is the only way i use to flip the player object of the way they're facing
        }
        if (kb.dKey.isPressed) 
        {
            moveInput = 1;
            transform.localScale = new Vector2(1.516f,1.5f);
        }
        if (kb.spaceKey.wasPressedThisFrame) Jump(); //If space is pressed the Jump func will be called
    }
    private void Move()
    {
        rb.linearVelocityX = moveInput * moveSpeed; // Sets the velocity on the x axis to the move input multiplied by move speed
    }

    private void Jump()
    {
        if (IsGrounded())
        {
            rb.linearVelocityY = jumpPower; //Checks to see if the player is on the ground then applies the jump power to the players Y velocity
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundChecker, groundLayer); //Checks to see if the players is on the gorund by assigning a layer
    }
    
}
