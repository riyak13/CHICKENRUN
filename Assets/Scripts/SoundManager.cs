using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour 
{
	public AudioSource JumpSource;
	public AudioSource GameOverSource;
	public AudioSource MusicSource;
	public static SoundManager instance = null;



	void Awake () 
	{
		if (instance == null) //check before game starts and make sure it is under one sound control
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		DontDestroyOnLoad (gameObject);  //do not destroy during game play
		
	}




}
