using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public GameManager GameManager;
    public GameObject Semicolon;
    
    public static bool HasSemicolon = false;
    
    private bool isGrounded;
    private int jumpCount = 0;
    public LayerMask groundLayer;
    
    // I know this should be a separate class. this is just for testing purposes
    void Jump()
    {
        // Make the bird jump by applying an upward force.
        rb.linearVelocity = Vector2.up * GameParameters.PlayerJumpForce;
        jumpCount += 1;
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

    void CheckIsGrounded()
    {
        Ray ray = default;
        Debug.DrawRay(ray.origin, ray.direction, Color.red, 0.5f);

        ray = new Ray(transform.position, -transform.up);
        if (Physics2D.Raycast(rb.transform.position, Vector2.down, 0.1f, groundLayer.value)) 
        {
            isGrounded = true;
            jumpCount = 0;
        }
        else 
        {
            isGrounded = false;
        }
    }
    
    void Update()
    {
        CheckIsGrounded();

        if (Keyboard.current.spaceKey.wasPressedThisFrame && jumpCount < 1)
            //(Input.GetMouseButtonDown(0)) // Check for mouse click or tap.
        {
            Jump();
            isGrounded = false;
        }
        else
        {
                return;
        }
    }

    void LateUpdate()
    {
        if (KeyboardInput.IsInteractKeyPressed() && HasSemicolon)
        {
            PlaceSemicolon();
            Debug.Log("Placing Item, allegedly");
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("DieDieDie"))
        {
            GameManager.GameLost();
        }
    }
    
    void PlaceSemicolon()
    {
        Vector3 offset = new Vector3(0.2f, -0.3f, 0f);
        Vector3 spawnPosition = spriteRenderer.transform.position + offset;
        Instantiate(Semicolon, spawnPosition, Quaternion.identity);
        
        HasSemicolon = false;
    }
}
