using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    
    // I know this should be a seperate class. this is just for testing purposes
    void Jump()
    {
        // Make the bird jump by applying an upward force.
        rb.linearVelocity = Vector2.up * GameParameters.PlayerJumpForce;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
    
    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
            //(Input.GetMouseButtonDown(0)) // Check for mouse click or tap.
        {
            Jump();
        } 
    }
}
