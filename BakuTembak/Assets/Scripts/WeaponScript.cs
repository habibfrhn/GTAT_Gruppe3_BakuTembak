using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    //using empty object to spawn the bullet
	public Transform firePoint;
	//bullet sprite
	public GameObject bulletPrefab;
	
	// Update is called once per frame
	void Update () 
    {
		// if input is pressed
		if (Input.GetButtonDown("Fire1"))
		{
			//call the schoot funtion
			Shoot();
		}
	}

	void Shoot ()
	{
		//spawn bullets
		Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
	}
}
