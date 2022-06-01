using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    //maximum health
	public int maxHealth = 100;
    //current health
	public int currentHealth;

	//slide healthbar
	public HealthBar healthBar;
	//rigid body
	public Rigidbody2D rb;
	//animator
	public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
		rb = GetComponent<Rigidbody2D>();
    }

	// take damage function
	void takeDamage(int damage)
	{
		//current health damaged
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);
	}

	//collision trigger  with enemy
	private void OnTriggerEnter2D(Collider2D enemy)
     {
         if(currentHealth > 0 && enemy.gameObject.tag == "Enemy")
         {
             takeDamage(10);
			 //knockback
			 rb.velocity = new Vector3(-50, 10, 0);
         }
		 
		 if(currentHealth<=0)
		 {
			 //lose the game
			 Debug.Log("Game ends!");
			 //dead animation
			 animator.SetBool("isDying", true);
			 //pause
			 Time.timeScale = 0;
		 }

     }
}
