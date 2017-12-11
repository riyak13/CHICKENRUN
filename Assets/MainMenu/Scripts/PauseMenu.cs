using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PauseMenu : MonoBehaviour {

	public string mainMenu; 
	public bool isPaused;
	public GameObject pauseMenuCanvas; 

	// Update is called once per frame
	void Update () 
	{
		if (isPaused) 
		{
			pauseMenuCanvas.SetActive (true); //if the game is paused the pause menu will show up 
			Time.timeScale = 0f; //the speed of the game is 1 so if we set it 
								//to zero it will pause
		} else {
			pauseMenuCanvas.SetActive (false); //not pause it will be hidden
			Time.timeScale = 1f; //and if the game is unpause
								 //it will return to its normal speed 
		}

		if (Input.GetKeyDown(KeyCode.Escape)) //if the escape button is pressed
											  //the game will be paused/unpaused 
			{
				isPaused = !isPaused; 
			}
	}

	public void Resume ()
	{
		isPaused = false; 
	}

	public void Quit () 
	{
		SceneManager.LoadScene (mainMenu); 	//if the player clicks 
											//the main menu button it will return to the main menu scene 
	}
}
