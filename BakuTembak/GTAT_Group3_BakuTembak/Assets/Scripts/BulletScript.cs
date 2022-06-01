using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 10f;
	public int damage = 20;
	public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		// bullet acceleration
		rb.velocity = transform.right * speed;
	}

	void OnTriggerEnter2D (Collider2D hitInfo)
	{
		// bullet collider find enemy or hit other collider
		EnemyScript enemy = hitInfo.GetComponent<EnemyScript>();
		if (enemy != null)
		{
			//enemy take damage
			enemy.TakeDamage(damage);
		}

		//destroy bullet
		Destroy(gameObject);
	}
}
