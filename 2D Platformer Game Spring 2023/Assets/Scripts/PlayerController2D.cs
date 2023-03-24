using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    // Player Stats
    [Header("Player Stats")]
    public float speed; // How fast the player is going to move
    public float jumpForce; // How high the player will jump
    private float moveInput; // Get move input value

    // Player Rigidbody
    [Header("Rigidbody Component")]
    private Rigidbody2D rb;
    private bool isFacingRight = true;

    // Player Jump 
    [Header("Player Jump Settings")]
    private bool isGrounded = true;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public bool doubleJump;


    // Start is called before the first frame update
    void Start()
    {
        // Get rigidbody component reference
      rb = GetComponent<Rigidbody2D>();
    }
     
    // Fixed Update is called a fixed or set number of frames. This works best with physics based movement
    void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround); // Define what is ground and Check for ground  
      
        moveInput = Input.GetAxis("Horizontal"); // Get the Horizontal keybinding which will return a value between -1 and 1
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);// Move the player left and right

        // If the player is moving right but facing left flip the player right
        if(!isFacingRight && moveInput > 0)
        {
            FlipPlayer();
        }
        // If the player is moving left but facing right flip the player left
        else if(isFacingRight && moveInput < 0)
        {
            FlipPlayer();
        }      
       
    }

     void FlipPlayer()
    {
        isFacingRight = !isFacingRight;
        Vector3 scaler = transform.localScale; //Local variable that stores localscale value 
        scaler.x *= -1; // Flip the sprite graphic
        transform.localScale = scaler;

    }
  
    // Update is called once per frame. We will us Update for the jump as we will need every frame. Fixed Update skips frames.

    void Update()
    {      
        if(isGrounded)
        {
            doubleJump = true; 
        }

        if(Input.GetKeyDown(KeyCode.Space) && doubleJump)
        {
            rb.velocity = Vector2.up * jumpForce;//Makes the player jump
            doubleJump = false;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !doubleJump && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;// Apply jumpForce to player making the player jump
        }
    }
   
}