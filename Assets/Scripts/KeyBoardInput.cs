using UnityEngine;
using UnityEngine.InputSystem;

public class KeyboardInput : MonoBehaviour
{
    public Player Player;
    
    private static int lastConsumedFrame = -1;
    
    public static bool IsInteractKeyPressed()
    {
        if (Keyboard.current == null) return false;
        bool keyIsPressed = Keyboard.current[GameParameters.Interact].wasPressedThisFrame;
        
        if (keyIsPressed && Time.frameCount == lastConsumedFrame)
        {
            return false;
        }

        return keyIsPressed;
    }
    
    public static void ConsumeInteractInput()
    {
        lastConsumedFrame = Time.frameCount;
    }
    
    void Update()
    {
        Keyboard keyboard = Keyboard.current;
        if (keyboard == null) return;
       
        if (keyboard.aKey.isPressed)
        {
            Player.MoveManually(Vector2.left);
        }
        else if (keyboard.dKey.isPressed)
        {
            Player.MoveManually(Vector2.right);
        }
        
        /*else
        {
            Player.StopMoving();
        }
        */
    }
}