using UnityEngine;
using System.Collections;

public class BarrierTrigger : MonoBehaviour {

	public BarrierScript barrier;

	public bool ignoreTrigger;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (ignoreTrigger)
			return;

		if(other.tag=="Player")
		{
			barrier.BarrierUp ();
		}
		
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (ignoreTrigger)
			return;

		if(other.tag=="Player")

		if(other.tag=="Player")
		{
			barrier.BarrierDown ();
		}

	}

	public void Toggle(bool state)
	{
		if (state)
			barrier.BarrierUp ();
		else
			barrier.BarrierDown ();
	}

	void OnDrawGizmos()
	{
		if (!ignoreTrigger) 
		{
			BoxCollider2D barrier = GetComponent<BoxCollider2D> ();

			Gizmos.DrawWireCube (transform.position, new Vector2 (barrier.size.x, barrier.size.y));
		}
	}
}
