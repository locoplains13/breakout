using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    public bool isPaused = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }

    void pause()
    {
        Time.timeScale = 0;
        pauseMenuPanel.SetActive(true);
        isPaused = !isPaused;
    }

    public void resume()
    {
        Time.timeScale = 1;
        pauseMenuPanel.SetActive(false);
        isPaused = !isPaused;
    }

    public void quitGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
