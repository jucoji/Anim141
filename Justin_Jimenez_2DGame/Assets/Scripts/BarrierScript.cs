using UnityEngine;
using System.Collections;

public class BarrierScript : MonoBehaviour {

	Animator anim;


	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void BarrierUp()
	{
		anim.SetBool ("Opens", true);

	}

	public void BarrierDown()
	{
		anim.SetBool ("Opens", false);

	}


}
