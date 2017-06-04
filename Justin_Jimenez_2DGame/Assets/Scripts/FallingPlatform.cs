using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour {

	private Rigidbody2D rb;
	private Collider2D collider;

	public float fallTime;

	private Vector2 initialPos;
	public int maxYPosition = -1;


	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
		collider = GetComponent<Collider2D> ();

		initialPos = transform.position;
	}
	
	void Update ()
	{
		if (gameObject.transform.position.y <= maxYPosition) 
		{
			transform.position = initialPos;
			rb.isKinematic = true;
			collider.enabled = true;


		}
	}

	IEnumerator platformShake(float fallTime)
	{
		while (fallTime > 0) 
		{
			rb.position = new Vector2 (rb.position.x + (Random.insideUnitCircle.x * 0.05f), rb.position.y);
			yield return new WaitForSeconds (0.0001f);
			fallTime -= Time.deltaTime;
		}

		rb.isKinematic = false;
	}

	void OnCollisionEnter2D (Collision2D col) 
	{
		if (col.collider.CompareTag ("Player")) 
		{
			StartCoroutine (platformShake (fallTime));

		}
	}

	void OnCollisionExit2D (Collision2D col) 
	{
		if (col.collider.CompareTag ("Player")) 
		{
			rb.isKinematic = false;
			collider.enabled = false;
		}
	}
}
