using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public CanvasGroup GameOverScreen;
    void Start()
    {
        CanvasGroupDisplayer.Hide(GameOverScreen);
    }

    
    public void EndGame()
    {
        CanvasGroupDisplayer.Show(GameOverScreen);
    }

    public void OnClickRestartGame()
    {
        CanvasGroupDisplayer.Hide(GameOverScreen);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
