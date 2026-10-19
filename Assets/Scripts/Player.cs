using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public GameManager GameManager;
    private bool isGrounded;

    // I know this should be a separate class. this is just for testing purposes
    void Jump()
    {
        rb.linearVelocity = Vector2.up * GameParameters.PlayerJumpForce;
    }
    
    public void MoveManually(Vector2 direction)
    {
        //if (!Game.IsGameRunning())
            //return;
        Move(direction);
        
    }
    public void Move(Vector2 direction)
    {
        // Useless for now, could be used later.
        //FaceCorrectDirection(direction);
        Vector2 movementAmount = direction * (GameParameters.PlayerMovementSpeed * Time.deltaTime);
        spriteRenderer.transform.Translate(movementAmount.x,0,0);
        spriteRenderer.transform.position = SpriteTools.ConstrainToScreen(spriteRenderer);
        //animator.SetFloat("Horizontal", Mathf.Abs(movementAmount.x));
    }
    
    public LayerMask groundLayer;

    void CheckIsGrounded()
    {
        Ray ray = default;
        Debug.DrawRay(ray.origin, ray.direction, Color.red, 0.5f);

        ray = new Ray(transform.position, -transform.up);
        if (Physics2D.Raycast(rb.transform.position, Vector2.down, 0.1f, groundLayer.value)) 
        {
            isGrounded = true;
        }
        
        else 
        {
            isGrounded = false;
        }
        
    }
    
    // Update is called once per frame
    void Update()
    {
        CheckIsGrounded();

        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
            //(Input.GetMouseButtonDown(0)) // Check for mouse click or tap.
        {
            Jump();
            print("im trying really fucking hard to jump");
            isGrounded = false;
        }
        else
        {
                print("I shouldn't jump rn tbh");
                return;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("DieDieDie"))
        {
            GameManager.EndGame();
        }
    }
    
}
