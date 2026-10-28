using UnityEngine;
using UnityEngine.InputSystem;

public class KeyboardInput : MonoBehaviour
{
    public Player Player;
    
    private static int lastConsumedFrame = -1;
    
    public static bool IsInteractKeyPressed()
    {
        if (Keyboard.current == null) return false;
        bool interactKeyIsPressed = Keyboard.current[GameParameters.Interact].wasPressedThisFrame;
        
        if (interactKeyIsPressed && Time.frameCount == lastConsumedFrame)
        {
            return false;
        }

        return interactKeyIsPressed;
    }

    public static bool IsCameraSwitchKeyPressed()
    {
        if (Keyboard.current == null) return false;
        bool cameraSwitchKeyIsPressed = Keyboard.current[GameParameters.CameraSwitch].wasPressedThisFrame;
        
        if (cameraSwitchKeyIsPressed && Time.frameCount == lastConsumedFrame)
        {
            return false;
        }
        
        return cameraSwitchKeyIsPressed;
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