using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI lives;
    public TextMeshProUGUI highScore;
    public GameObject ballObject;
    public GameObject levelGenerator;
    public GameObject winPanel;
    int scoreVar;
    int livesVar = 3;
    int highScoreVar;
    void Start()
    {
        Time.timeScale = 1.0f;
    }
    // Update is called once per frame
    void Update()
    {
        scoreVar = ballObject.GetComponent<ball>().score;
        score.text = ("Score: " + scoreVar.ToString());
        highScoreUpdate();
        livesVar = ballObject.GetComponent<ball>().lives;
        lives.text = ("Lives " + livesVar.ToString());
        if (levelGenerator.GetComponent<level>().bricks == 0)
        {
            //show win screen 
            ballObject.GetComponent<ball>().ballShot = false;
            winPanel.SetActive(true);
        }
    }
    public void highScoreUpdate()
    {
        if (PlayerPrefs.HasKey("SavedHighScore"))
        {
            if (scoreVar > PlayerPrefs.GetInt("SavedHighScore"))
            {
                PlayerPrefs.SetInt("SavedHighScore", scoreVar);
                highScoreVar = PlayerPrefs.GetInt("SavedHighScore");
            }
        }
        else
        {
            PlayerPrefs.SetInt("SavedHighScore", scoreVar);
            highScoreVar = scoreVar;
            highScore.text = ("High Score: " + highScoreVar.ToString());
        }
        livesVar = ballObject.GetComponent<ball>().lives;
        lives.text = ("Lives " + livesVar.ToString());
        highScore.text = ("High Score: " + PlayerPrefs.GetInt("SavedHighScore").ToString());
    }
}
