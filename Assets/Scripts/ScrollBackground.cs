using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour 
{
	private BoxCollider2D backgroundCollider;
	private float backgroundHorizontalLength; 


	void Start () 
	{
		backgroundCollider = GetComponent<BoxCollider2D> ();
		backgroundHorizontalLength = backgroundCollider.size.x;
			
		
	}
	

	void Update () 
	{
		if (transform.position.x < -backgroundHorizontalLength) //define when to start scrolling
		{
			repositionBackground ();
		}
		
	}


	private void repositionBackground()
	{
		Vector2 backgroundOffset = new Vector2 (backgroundHorizontalLength * 2f, 0); //define the reposition of background
		transform.position = (Vector2)transform.position + backgroundOffset;
	}





}
