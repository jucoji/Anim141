using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float jumpHeight;
	public float sprintMultiplier;

	private float moveVelocity;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;


	private bool doubleJumped;

	private Animator anim;

	public Transform firePoint;
	public GameObject projectile;

	public float shotDelay;
	private float shotDelayCounter;

	public float knockback;
	public float knockbackLength;
	public float knockbackCount;
	public bool knockFromRight;

	public bool onLadder;
	public float climbSpeed;
	private float climbVelocity;
	private float gravityStore;

	public bool onPlatform;

	private Rigidbody2D rb;

	public Grabber grabber;

	public bool canMove;

	public LayerMask whatIsLadderTop;
	public bool onLadderTop;

	BoxCollider2D boxColl;
	CircleCollider2D circleColl;






	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();

		anim = GetComponent<Animator> ();

		gravityStore = rb.gravityScale;

		boxColl = gameObject.GetComponent<BoxCollider2D> ();
		circleColl = gameObject.GetComponent<CircleCollider2D> ();

	}

	void FixedUpdate() 
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
		onLadderTop = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsLadderTop);

	}

	// Update is called once per frame
	void Update () {
		/*if (!canMove) 
		{
			rb.isKinematic = true;
			return;
		}
		*/

	
		rb.isKinematic = false;

			if (grounded) {
				doubleJumped = false;
			}

			anim.SetBool ("Grounded", grounded);
			
		if (Input.GetButtonDown ("Jump") && grounded) {

				rb.velocity = new Vector2 (rb.velocity.x, jumpHeight);
			}

			if (Input.GetButtonDown ("Jump") && !doubleJumped && !grounded) {
				rb.velocity = new Vector2 (rb.velocity.x, jumpHeight);
				doubleJumped = true;
			}
						
	

			//moveVelocity = 0f;

			moveVelocity = moveSpeed * Input.GetAxisRaw ("Horizontal");

			if (Input.GetButton ("Fire3")) {
				moveVelocity = moveSpeed * sprintMultiplier * Input.GetAxisRaw ("Horizontal");
			}


			if (knockbackCount <= 0) {
				rb.velocity = new Vector2 (moveVelocity, rb.velocity.y);
			} else {
				if (knockFromRight)
					rb.velocity = new Vector2 (-knockback, knockback);
				if (!knockFromRight)
					rb.velocity = new Vector2 (knockback, knockback);

				knockbackCount -= Time.deltaTime;
			}

			//Flip player
			if (rb.velocity.x > 1)
				transform.localScale = new Vector3 (1f, 1f, 1f);
			else if (rb.velocity.x < -1)
				transform.localScale = new Vector3 (-1f, 1f, 1f);


			if (anim.GetBool ("Cane"))
				anim.SetBool ("Cane", false);

			if (Input.GetButtonDown ("Fire1")) {
				anim.SetBool ("Cane", true);
	
			}

			/*	if (Input.GetButtonDown ("Fire2")) 
		{
			Instantiate (projectile, firePoint.position, firePoint.rotation);
			shotDelayCounter = shotDelay;
		} */

			if (Input.GetButton ("Fire2")) {
				shotDelayCounter -= Time.deltaTime;

				if (shotDelayCounter <= 0) {
					shotDelayCounter = shotDelay;
					Instantiate (projectile, firePoint.position, firePoint.rotation);
				}
			}
			


			anim.SetFloat ("Speed", Mathf.Abs (rb.velocity.x));

			if (onLadder) {
				rb.gravityScale = 0f;

				climbVelocity = climbSpeed + Input.GetAxisRaw ("Vertical") * 4;
				rb.velocity = new Vector2 (rb.velocity.x, climbVelocity);
			}

			if (!onLadder) {
				rb.gravityScale = gravityStore;
			}
		

	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.transform.tag == "MovingPlatform") 
		{
			transform.parent = other.transform;
		}

		if (other.transform.tag == "Platform") 
		{
			onPlatform = true;
		}

	
	}
	void OnCollisionExit2D(Collision2D other)
	{

		if (other.transform.tag == "MovingPlatform" ) 
		{
			transform.parent = null;
		}

		if (other.transform.tag == "Platform") {
			onPlatform = false;
		}

	
	}
		
}
