using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI lives;
    public TextMeshProUGUI highScore;
    public GameObject ballObject;
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
