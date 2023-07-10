using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverPlayerUI;
    public GameObject gameOverBossUI;

    public void gameOverPlayer()
    {
        gameOverPlayerUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void gameOverBoss()
    {
        gameOverBossUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void gameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void gameNewGame()
    {
        SceneManager.LoadScene("MainGame");
        Time.timeScale = 1f;
    }

    public void gameMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void gameQuit()
    {
        Application.Quit();
    }
}
