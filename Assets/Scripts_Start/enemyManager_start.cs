﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManager_start : MonoBehaviour {

	Vector3 randomPosition;
	float spawnFrequency=2f;

	// Use this for initialization
	void Start () {
	
		InvokeRepeating ("spawnEnemy", 1f, spawnFrequency);

	}

	void spawnEnemy()
	{
		//generate a random Y position for spawning.
		float randomZ=Random.Range(-4.64f, -10.3f);

		randomPosition= new Vector3(
						14.5f, 14.69721f, randomZ
						);

		//Instantiate the new enemy.
		Instantiate (Resources.Load ("enemySprite_start", typeof(GameObject)), 
			randomPosition, 
			Quaternion.Euler(new Vector3(-90, -90, 0)) );
		
	}


}
