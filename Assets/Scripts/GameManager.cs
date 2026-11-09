using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public CanvasGroup GameOverScreen;
    public CanvasGroup GameWonScreen;
    public CanvasGroup PauseMenuPanel;
    public UI UI;
    void Start()
    {
        CanvasGroupDisplayer.Hide(GameOverScreen);
        CanvasGroupDisplayer.Hide(GameWonScreen);
        CanvasGroupDisplayer.Hide(PauseMenuPanel);
        UI.UnSendText();
    }

    private void OnEnable()
    {
        GameStateManager.OnStateChanged += HandleStateChanged;
    }

    private void OnDisable()
    {
        GameStateManager.OnStateChanged -= HandleStateChanged;
    }
    
    private void HandleStateChanged(GameState newState)
    {
        if (newState == GameState.Paused)
        {
            GamePaused();
        }
        else if (newState == GameState.Gameplay)
        {
            GameResumed();
        }
    }

    private void GamePaused()
    {
        CanvasGroupDisplayer.Show(PauseMenuPanel); 
        PauseMenuPanel.transform.SetAsLastSibling();
    }

    private void GameResumed()
    {
        CanvasGroupDisplayer.Hide(PauseMenuPanel);
    }
    
    public void GameLost()
    {
        CanvasGroupDisplayer.Show(GameOverScreen);
    }

    public void OnClickRestartGame()
    {
        CanvasGroupDisplayer.Hide(GameOverScreen);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameWon()
    {
        CanvasGroupDisplayer.Show(GameWonScreen);
    }
}
