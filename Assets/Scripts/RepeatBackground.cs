using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour //repeat the background once to make it possible to scroll
{
	private Rigidbody2D rgbd2d; 




	void Start () 
	{
		rgbd2d = GetComponent<Rigidbody2D> (); //adding physics to the background world
		rgbd2d.velocity = new Vector2 (GameControl.instance.ScrollSpeed, 0);
		
	}
	

	void Update () 
	{
		if (GameControl.instance.GameOver == true) //background stops scrolling when gameover
		{
			rgbd2d.velocity = new Vector2(0,0);
			
		}
		
	}
}
