using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour 
{
	public AudioSource efxSource;
	public static SoundManager instance = null;

	public float lowPitchRange = .95f; //-5% of original pitch
	public float highPitchRange = 1.05f; //+5% of original pitch


	void Awake () 
	{
		if (instance == null) //check before game starts and make sure it is under one sound control
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		DontDestroyOnLoad (gameObject);
		
	}


	public void PlaySingle(AudioClip clip) // to be called by Chick class to play gameover sound effect 
	{
		efxSource.clip = clip;
		efxSource.Play ();
	}

	public void RamdomizeSfx (params AudioClip[] clips) // creating random variation of clips at random pitches, so the sound won't be too boring
	{
		int randomIndex = Random.Range (0, clips.Length);
		float randomPitch = Random.Range (lowPitchRange, highPitchRange);

		efxSource.pitch = randomPitch;
		efxSource.clip = clips[randomIndex];
		efxSource.Play ();

	}



}
