using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

	private float health, remainingHealth;
	private string id;


	public void setHealth (float initialHealth, string id)
	{
		this.id = id;
		health = initialHealth;
		remainingHealth = initialHealth;
	}

	public float getRemainingHealth ()
	{
		return remainingHealth;
	}

	public void damage (float damage)
	{
		remainingHealth -= damage;
	}

	void Update ()
	{
		if (remainingHealth <= 0) {
			Destroy (GameObject.Find (id));
		}
	}


}
