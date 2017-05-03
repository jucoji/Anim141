using UnityEngine;
using System.Collections;

public class HurtEnemyOnContact : MonoBehaviour 
{

	public int damageToGive;

	public float bounchOnEnemy;

	private Rigidbody2D rb;

	// Use this for initialization
	void Start () 
	{
		rb = transform.parent.GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Enemy" || other.tag == "FlyingEnemy") 
		{
			other.GetComponent<EnemyHealthManager> ().giveDamage (damageToGive);
			rb.velocity = new Vector2 (rb.velocity.x, bounchOnEnemy);
		}
	}
}
