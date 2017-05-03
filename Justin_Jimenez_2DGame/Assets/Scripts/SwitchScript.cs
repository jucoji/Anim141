using UnityEngine;
using System.Collections;

public class SwitchScript : MonoBehaviour {

	public BarrierTrigger[] barrierTrig;

	Animator anim;

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D()
	{
		anim.SetBool ("goDown", true);

		foreach (BarrierTrigger trigger in barrierTrig) 
		{
			trigger.Toggle (true);
		}
	}


	void OnTriggerExit2D()
	{
		anim.SetBool ("goDown", false);
		foreach (BarrierTrigger trigger in barrierTrig) 
		{
			trigger.Toggle (false);
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.cyan;
		foreach (BarrierTrigger trigger in barrierTrig)
			Gizmos.DrawLine (transform.position, trigger.transform.position);
	}

}
