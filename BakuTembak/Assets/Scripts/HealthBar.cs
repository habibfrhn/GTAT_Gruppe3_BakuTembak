using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

	public Slider slider;

	// set max health
	public void SetMaxHealth(int health)
	{
		//slider value changes here
		slider.maxValue = health;
		slider.value = health;
	}

    public void SetHealth(int health)
	{
		slider.value = health;
	}

}
