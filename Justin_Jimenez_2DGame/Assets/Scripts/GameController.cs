using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	public GameObject[] hazards;
	public Vector3 spawnValues;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public Quaternion spawnRotation;

	public int hazardCount;
	public int randomRange;

	void Start () 
	{


	}
	
	 IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds (startWait);
		while (true) 
		{
			for (int i = 0; i < hazardCount; i++) 
			{
				GameObject hazard = hazards[Random.Range(0,hazards.Length)];
				Vector3 spawnPosition = new Vector3 (Random.Range ((spawnValues.x - randomRange), spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}

	void OnTriggerEnter2D (Collider2D other) 
	{
		if (other.name == "Player") 
		{
			StartCoroutine (SpawnWaves());
		}
	}

	void OnTriggerExit2D (Collider2D other) 
	{
		if (other.name == "Player") 
		{
			StopAllCoroutines();
		}
	}
}
	 
