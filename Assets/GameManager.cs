using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI highScore;
    public GameObject ballObject;
    int scoreVar;
    int highScoreVar = 0;

    void Start()
    {
        Time.timeScale = 1.0f;
    }
    // Update is called once per frame
    void Update()
    {
        scoreVar = ballObject.GetComponent<ball>().score;
        score.text = ("Score: " + scoreVar.ToString());
        if (scoreVar > highScoreVar)
        {
            highScoreVar = scoreVar;
            highScore.text = ("High Score: " + highScoreVar.ToString());
        }
    }
}
