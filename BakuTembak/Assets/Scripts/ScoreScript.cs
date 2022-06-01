using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text MyScore;
    private int ScoreNumber;
    // Start is called before the first frame update
    void Start()
    {
       ScoreNumber = 0;
       MyScore.text = "Score: " + ScoreNumber; 
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D Coin)
    {
        if (Coin.tag == "Coin")
        {
            ScoreNumber++;
            Destroy(Coin.gameObject);
            MyScore.text = "Score: " + ScoreNumber;
        }
    }
}
