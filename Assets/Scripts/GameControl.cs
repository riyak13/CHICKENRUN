using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameControl : MonoBehaviour 
{
	public static GameControl instance; 

	public GameObject GameOverText; //canvas text to be shown under defined situations
	public Text ScoreText;


	public bool GameOver = false;

	private int score = 0;

	public float ScrollSpeed = -1.5f; // background scrolling speed



	void Awake () // before game start, check to make sure there is a game control
	{
		if (instance == null) 
		{
			instance = this;
		} 

	}



	void Update () // to be updated!!!
	{
		if (GameOver == true && Input.GetMouseButtonDown (0))  
		{
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
			SoundManager.instance.efxSource.Play ();
		} 


	}


	public void RepositionCollider(GameObject PowerupObject) 
	{
		int repositionXMin = 7; 
		int repositionXMax = 18;
		int repositionYMin = -4;
		int repositionYMax = 4;

		int repositionX = Random.Range (repositionXMin, repositionXMax);
		int repositionY = Random.Range (repositionYMin, repositionYMax);

		PowerupObject.transform.position = new Vector2(repositionX,repositionY);  // when a powerup object is hit, it gets repositioned offscreen at a random place, ready to reappear 

	}

	public void ChickScored () //increase and display score
	{
		if (GameOver) 
		{ 
			return; // do not score when game over
		} else 
		{
			score = score + 100; //increase score by 100 when hit a powerup object
			ScoreText.text = "Score: " + score.ToString (); // display the score when not gameover
		}
	
	}

	public void ChickDead()
	{
		GameOverText.SetActive (true); //display GAME OVER message when chick dies
		GameOver = true;

	}


}
