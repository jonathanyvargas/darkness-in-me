using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject pauseScreen;

    /// <summary>
    /// Show the game over screen and pause the game
    /// </summary>
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    /// <summary>
    /// Pause the game and show the pause screen
    /// </summary>
    public void Pause()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    /// <summary>
    /// Unpause the game and remove the pause screen
    /// </summary>
    public void Resume(){
        Time.timeScale = 1f; 
        pauseScreen.SetActive(false);
    }

    /// <summary>
    /// Reload the game to restart
    /// </summary>
    public void Restart() 
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public bool isPauseScreenActive() {
        return pauseScreen.activeInHierarchy;
    }

        public bool isGameOverScreenActive() {
        return gameOverScreen.activeInHierarchy;
    }
}
