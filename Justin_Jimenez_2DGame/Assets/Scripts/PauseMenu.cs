using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour 
{
	public string levelSelect;
	public string mainMenu;

	public bool isPaused;
	public GameObject pauseMenuCanvas;

	private Rigidbody2D rb;
	public PlayerController player;

	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
		player = FindObjectOfType<PlayerController> ();
	}

	// Update is called once per frame
	void Update () 
	{
		if (isPaused) 
		{
			pauseMenuCanvas.SetActive (true);
			Time.timeScale = 0f;
			player.enabled = false;
		} else 
		{
			pauseMenuCanvas.SetActive (false);
			Time.timeScale = 1f;
			player.enabled = true;

		}


		if(Input.GetButtonDown("Cancel"))
			isPaused = !isPaused;
	}

	public void Resume()
	{
		isPaused = false;
	}

	public void LevelSelect()
	{
		SceneManager.LoadScene (levelSelect);
	}

	public void Quit()
	{
		SceneManager.LoadScene (mainMenu);
	}
}
