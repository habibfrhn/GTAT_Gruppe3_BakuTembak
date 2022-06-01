using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text score;
    public Text highScore;

    void Start() 
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void RollDice()
    {
        int number = Random.Range(1, 10);
        score.text = number.ToString();

        if (number > PlayerPrefs.GetInt("HighScore", 0))
        {
        PlayerPrefs.SetInt("HighScore", number);
        highScore.text = number.ToString();

        }
    }

    public void Reset() {
        PlayerPrefs.DeleteKey("HighScore");
        highScore.text = "0";
    }
}
