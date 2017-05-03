using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour 
{
	public GameObject platform;

	public float moveSpeed;

	private Transform currentPoint;

	public Transform[] points;

	public int pointsSelection;

	// Use this for initialization
	void Start () 
	{
		currentPoint = points [pointsSelection];
	}
	
	// Update is called once per frame
	void Update () 
	{
		platform.transform.position = Vector3.MoveTowards (platform.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);

		if (platform.transform.position == currentPoint.position) 
		{
			pointsSelection++;

			if (pointsSelection == points.Length) 
			{
				pointsSelection = 0;
			}

			currentPoint = points [pointsSelection];
		}

	}
}
