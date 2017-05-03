using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour {

	public float moveSpeed;
	public bool moveRight;

	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask whatIsWall;
	private bool hittingWall;

	private bool notAtEdge;
	public Transform edgeCheck;

	private Rigidbody2D rb;

	// Use this for initialization
	void Start () 
	{

		rb = GetComponent<Rigidbody2D> ();
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		hittingWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, whatIsWall);

		notAtEdge = Physics2D.OverlapCircle (edgeCheck.position, wallCheckRadius, whatIsWall);


		if (hittingWall || !notAtEdge) 
		{
			moveRight = !moveRight;
		}


		if (moveRight) 
		{
			transform.localScale = new Vector3 (-1f, 1f, 1f);
			rb.velocity = new Vector2 (moveSpeed, rb.velocity.y);
		} 
		else 
		{
			transform.localScale = new Vector3 (1f, 1f, 1f);
			rb.velocity = new Vector2 (-moveSpeed, rb.velocity.y);
		}
	}
}
