using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour {

	public string startLevel;
	public string levelToLoad;


	public void NewGame()
	{
		SceneManager.LoadScene (startLevel);

	}

	public void LevelSelect()
	{
		SceneManager.LoadScene (levelToLoad);
	}

	public void QuitGame()
	{
		Debug.Log ("Game Exited");
		Application.Quit ();
	}

}
