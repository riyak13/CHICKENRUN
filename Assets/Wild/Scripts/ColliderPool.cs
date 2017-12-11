using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderPool : MonoBehaviour 
{
	
	public GameObject ColliderPrefab;
	public int ColliderPoolSize = 3;
	public float SpawnRate = 4f; // how often to put a new collider
	public float YPositionMin = -3f;
	public float YPositionMax = 5f;

	private GameObject[] colliders;
	private Vector2 colliderPoolPosition = new Vector2 (-15f, -25f); //offscreen position  
	private float timeSinceLastSpawned; // time since the last collider appeared
	private float spawnPositionX = 2f; // position of new collider along X axis
	float spawnPositionY;
	private int currentCollider = 0;


	void Start () 
	{
		timeSinceLastSpawned = 0f;
		colliders = new GameObject[ColliderPoolSize];
		for (int i = 0; i < ColliderPoolSize; i++) //loop through the array and reposition collider
		{
			colliders [i] = (GameObject)Instantiate (ColliderPrefab, colliderPoolPosition, Quaternion.identity); //instantiate objects, store in the array 
		}
	}
	

	void Update () //timer to check when to reposition new colliders
	{
		timeSinceLastSpawned += Time.deltaTime;
		if (GameControl.instance.GameOver == false && timeSinceLastSpawned >= SpawnRate) 
		{
			timeSinceLastSpawned = 0f;
			spawnPositionY = Random.Range (YPositionMin, YPositionMax); // position of new collider along Y axis
			colliders[currentCollider].transform.position = new Vector2(spawnPositionX, spawnPositionY); //define X-Y coordinaates for current collider

			currentCollider++;

			if (currentCollider >= ColliderPoolSize) // make sure the number of colliders do not exceed the pool size
			{
				currentCollider = 0;
			}

		}
	}
}
