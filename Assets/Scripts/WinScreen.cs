using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public GameObject levelGenerator;
    public GameObject winPanel;
    public void NextLevel()
    {
        winPanel.SetActive(false);
        levelGenerator.GetComponent<level>().GenerateLevel(2.5f, 10f);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
