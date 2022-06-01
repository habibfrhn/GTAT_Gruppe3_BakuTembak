using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D Player)
    {
        // if collides with player
        if (Player.tag == "Player")
        {
            //win the game
            Debug.Log("Win");
        }
        
    }       
    
}
