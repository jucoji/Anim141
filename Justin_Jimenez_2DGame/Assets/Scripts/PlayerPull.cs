using UnityEngine;
using System.Collections;

public class PlayerPull : MonoBehaviour {

	public float distance=1f;
	public LayerMask boxMask;

	GameObject box;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		Physics2D.queriesStartInColliders = false;
		RaycastHit2D hit= Physics2D.Raycast (transform.position, Vector2.right * transform.localScale.x, distance, boxMask);


		if (hit.collider != null && hit.collider.gameObject.tag == "Grabable" && Input.GetButtonDown ("Fire1")) {


			box = hit.collider.gameObject;
			box.GetComponent<FixedJoint2D> ().connectedBody = this.GetComponent<Rigidbody2D> ();
			box.GetComponent<FixedJoint2D> ().enabled = true;
			box.GetComponent<Grabber> ().beingPushed = true;
			box.GetComponent<Grabber> ().enabled = true;


		} else if (Input.GetButtonUp ("Fire1")) {
			box.GetComponent<FixedJoint2D> ().enabled = false;
			box.GetComponent<Grabber> ().beingPushed = false;
			box.GetComponent<Grabber> ().enabled = false;

		}

	}


	void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;

		Gizmos.DrawLine (transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);



	}
}