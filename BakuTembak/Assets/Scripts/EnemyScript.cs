using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // healtpoints
    public int health = 40;

	public GameObject deathEffect;

	public int kill=0;

	ScoreScript scoreScript;
    [SerializeField] GameObject Player;

	void Start()
    {
       scoreScript = Player.GetComponent<ScoreScript>();
    }
    
    //taking damage
    public void TakeDamage (int damage)
	{
		//reduce health
        health -= damage;

		if (health <= 0)
		{
			// if health below 0. Dead
            Die();
			kill+=2;
			UpdateScore();
		}
	}

    //Die function
	void Die ()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

	void UpdateScore()
	{
		scoreScript.ScoreNumber+=kill;
	}
}
