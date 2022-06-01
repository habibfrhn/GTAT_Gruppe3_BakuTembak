using UnityEngine;
using UnityEngine.UI;

public class HighScoreScript : MonoBehaviour
{
    public Text highScore;

    void Start() 
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void RollDice()
    {
        int number = Random.Range(1, 10);

        if (number > PlayerPrefs.GetInt("HighScore", 0))
        {
        PlayerPrefs.SetInt("HighScore", number);
        highScore.text = number.ToString();

        }
    }
}