using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	public LevelManager levelManager;

	public GameObject respawnParticle;



	// Use this for initialization
	void Start () 
	{
		levelManager = FindObjectOfType<LevelManager> ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player") 
		{
			levelManager.currentCheckpoint = gameObject;
			Instantiate (respawnParticle, transform.position, transform.rotation);
			Debug.Log ("Activated Checkpoint " + transform.position);
		}
	}
}
