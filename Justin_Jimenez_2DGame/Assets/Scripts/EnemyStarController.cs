﻿using UnityEngine;
using System.Collections;

public class EnemyStarController : MonoBehaviour {

	public float speed;

	public PlayerController player;

	//public GameObject enemyDeathEffect;
	public GameObject impactEffect;

	//public int pointsForKill;

	public float rotationSpeed;

	public int damageToGive;

	private Rigidbody2D rb;



	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
		player = FindObjectOfType<PlayerController> ();

		if (player.transform.position.x < transform.position.x) 
		{
			speed = -speed;
			rotationSpeed = -rotationSpeed;
		}

	}

	// Update is called once per frame
	void Update () 
	{
		rb.velocity = new Vector2 (speed, rb.velocity.y);
		rb.angularVelocity = rotationSpeed;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			//Instakill + score
			//Instantiate (enemyDeathEffect, other.transform.position, other.transform.rotation);
			//Destroy (other.gameObject);
			//ScoreManager.AddPoints (pointsForKill);

		//	other.GetComponent<EnemyHealthManager> ().giveDamage (damageToGive);

			HealthManager.HurtPlayer (damageToGive);
		}

		Instantiate (impactEffect, transform.position, transform.rotation);
		Destroy (gameObject);
	}
}
