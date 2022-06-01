using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

	public HealthBar healthBar;
	public Rigidbody2D rb;
	public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
		rb = GetComponent<Rigidbody2D>();
    }

	void takeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);
	}

	private void OnTriggerEnter2D(Collider2D enemy)
     {
         if(currentHealth > 0 && enemy.gameObject.tag == "Enemy")
         {
             takeDamage(10);
			 rb.velocity = new Vector3(-50, 10, 0);
         }
		 
		 if(currentHealth<=0)
		 {
			 Debug.Log("Game ends!");
			 animator.SetBool("isDying", true);
			 Time.timeScale = 0;
		 }

     }
}
