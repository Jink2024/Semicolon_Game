using System;
using UnityEngine;

public enum GameState
{
    Gameplay,
    Paused
}

public class GameStateManager : MonoBehaviour
{
    public static event Action<GameState> OnStateChanged;

    public static GameState CurrentState { get; private set; } = GameState.Gameplay;

    private void Update()
    {
        if (KeyboardInput.IsPauseKeyPressed())
        {
            if (CurrentState == GameState.Gameplay)
            {
                SetState(GameState.Paused);
            }
            else if (CurrentState == GameState.Paused)
            {
                SetState(GameState.Gameplay);
            }
        }
    }

    public static void SetState(GameState newState)
    {
        if (CurrentState == newState) return;

        CurrentState = newState;
        
        if (CurrentState == GameState.Paused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
        OnStateChanged?.Invoke(CurrentState);
    }
}
