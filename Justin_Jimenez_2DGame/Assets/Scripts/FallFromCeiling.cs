using UnityEngine;
using System.Collections;

public class FallFromCeiling : MonoBehaviour {

	private Rigidbody2D rb;

	public float fallTime;

	private Vector2 initialPos;
	public int maxYPosition = -1;


	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
		initialPos = transform.position;

	
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.y <= maxYPosition) 
		{
			transform.position = initialPos;
			rb.isKinematic = true;
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

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player")  
		{
		//	rb.isKinematic = false;
			StartCoroutine (platformShake (fallTime));
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.name == "Player")  
		{
			rb.isKinematic = false;

		}
	}
}
