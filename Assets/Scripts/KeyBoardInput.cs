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

    public static bool IsPauseKeyPressed()
    {
        if (Keyboard.current == null) return false;
        bool pauseKeyIsPressed = Keyboard.current[GameParameters.Pause].wasPressedThisFrame;

        if (pauseKeyIsPressed && Time.frameCount == lastConsumedFrame)
        {
            return false;
        }
        
        return pauseKeyIsPressed;
    }
    
    public static void ConsumeInteractInput()
    {
        lastConsumedFrame = Time.frameCount;
    }
    
    void Update()
    {
        if (GameStateManager.CurrentState == GameState.Paused) return;
        
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