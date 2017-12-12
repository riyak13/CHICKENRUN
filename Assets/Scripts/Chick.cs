using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chick : MonoBehaviour 
{
	
	private Rigidbody2D rgbd2d; 
	private bool chickDead = false;  // Chick is not dead by default


	public float ForceUpward = 200f; // force for the chick to jump
	private Animator animator;

//	public AudioClip GetPowerupSound1; 
//	public AudioClip GetPowerupSound2;
//	public AudioClip GameOverSound;  

	void Start () 
	{
		rgbd2d = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();

	}


	void Update () 
	{ if (chickDead == false) 
		{ 		//when the game starts, the chick is contantly running by default
			    
			animator.SetTrigger ("run");
			if (Input.GetMouseButtonDown (0)) 
			{ 		// method to make the chick jump and fly
				rgbd2d.velocity = Vector2.zero;
				rgbd2d.AddForce (new Vector2 (0, ForceUpward));
				animator.SetTrigger ("fly");
			}
		}
	else if(chickDead == true)
		{
		   transform.position = new Vector2 (0,-3);
		} 

	}



	void OnCollisionEnter2D (Collision2D coll) 			//chick hit on different colliders
	{		
		if (coll.gameObject.name == "Berry" || coll.gameObject.name == "Water"|| coll.gameObject.name == "grain" || coll.gameObject.name == "cherry") {    // hit powerups to score
			GameControl.instance.RepositionCollider (coll.gameObject);
			GameControl.instance.ChickScored ();
			SoundManager.instance.JumpSource.Play (); 
		//SoundManager.instance.RamdomizeSfx(GetPowerupSound1, GetPowerupSound2);  // to play random sound effects during game play
		   
		} else if (coll.gameObject.name == "Stone" || coll.gameObject.name == "Eagle") //hit obstacles, damage health
		{	
			animator.SetTrigger ("die");
			GameControl.instance.ChickDead ();  // to be updated!!
			chickDead = true;
			SoundManager.instance.GameOverSource.Play (); 
			//SoundManager.instance.PlaySingle (GameOverSound); // // to play gameover sound effects when game over
			SoundManager.instance.MusicSource.Stop(); //stop background music when game over
		}
	}


}












