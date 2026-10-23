using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public CanvasGroup GameOverScreen;
    public CanvasGroup GameWonScreen;
    void Start()
    {
        CanvasGroupDisplayer.Hide(GameOverScreen);
        CanvasGroupDisplayer.Hide(GameWonScreen);
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
