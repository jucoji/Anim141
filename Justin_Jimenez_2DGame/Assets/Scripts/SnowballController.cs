using UnityEngine;
using System.Collections;

public class SnowballController : MonoBehaviour {

	public float speed;

	public PlayerController player;

	public GameObject enemyFreezeEffect;
	public GameObject impactEffect;

	public int pointsForFreeze;

	public float rotationSpeed;

	public int damageToGive;

	private Rigidbody2D rb;



	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
		player = FindObjectOfType<PlayerController> ();

		if (player.transform.localScale.x < 0) 
		{
			speed = -speed;
			rotationSpeed = -rotationSpeed;
			transform.localScale = new Vector3 (-1f, 1f, 1f);

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
		if (other.tag == "Enemy") 
		{
			//Instakill + score
			//Instantiate (enemyDeathEffect, other.transform.position, other.transform.rotation);
			//Destroy (other.gameObject);
			//ScoreManager.AddPoints (pointsForKill);

			other.GetComponent<EnemyHealthManager> ().giveDamage (damageToGive);
			other.GetComponent<EnemyPatrol> ().enabled = false;
			other.GetComponent<ShootAtPlayerInRange> ().enabled = false;


		}

		if (other.tag == "FlyingEnemy") 
		{
			other.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
			other.GetComponent<FlyerEnemyMove> ().moveSpeed = 0f;

		}

		Instantiate (impactEffect, transform.position, transform.rotation);
		Destroy (gameObject);
	}
}
