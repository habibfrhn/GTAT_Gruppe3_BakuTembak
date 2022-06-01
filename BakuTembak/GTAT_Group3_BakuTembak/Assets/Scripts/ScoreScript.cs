using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static ScoreScript Instance;
    void Awake()
    {
        Instance = this;
    }
    public Text MyScore;
    public int ScoreNumber;
    public Text highScore;

    // Start is called before the first frame update
    void Start()
    {
       //score starts at 0
       ScoreNumber = 0;
    }

    void Update()
    {
        //updating score for every frame
        MyScore.text = "Score: " + ScoreNumber; 
        GetHighScore();
    }

    void GetHighScore()
    {
        int number = ScoreNumber;
        // score.text = number.ToString();

        if (number > PlayerPrefs.GetInt("HighScore", 0))
        {
        PlayerPrefs.SetInt("HighScore", number);
        highScore.text = number.ToString();

        }
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D Coin)
    {
        // if collides with coin
        if (Coin.tag == "Coin")
        {
            // add score number
            ScoreNumber++;
            // ui score update
            MyScore.text = "Score: " + ScoreNumber;
            Destroy(Coin.gameObject);
        }

    }

}