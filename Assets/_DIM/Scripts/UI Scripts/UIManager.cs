using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject SettingsScreen;
    private GameObject currentScreen;

    /// <summary>
    /// Show the game over screen and pause the game
    /// </summary>
    public void GameOver()
    {
        currentScreen = gameOverScreen;
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    /// <summary>
    /// Pause the game and show the pause screen
    /// </summary>
    public void Pause()
    {
        if(currentScreen != null) {
            currentScreen.SetActive(false);
        }
        currentScreen = pauseScreen;
        pauseScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    /// <summary>
    /// Unpause the game and remove the pause screen
    /// </summary>
    public void Resume(){
        Time.timeScale = 1f; 
        currentScreen.SetActive(false);
    }

    /// <summary>
    /// Reload the game to restart
    /// </summary>
    public void Restart() 
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OpenSettings() {
        currentScreen.SetActive(false);
        currentScreen = SettingsScreen;
        SettingsScreen.SetActive(true);
    }

    public bool isPauseScreenActive() {
        return pauseScreen.activeInHierarchy;
    }

    public bool isGameOverScreenActive() {
        return gameOverScreen.activeInHierarchy;
    }
}
