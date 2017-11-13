using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript_start : MonoBehaviour {

	float enemySpeed=0.05f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate (new Vector3(0, -enemySpeed, 0));

	}

	public void enemyDefeated()
	{
		//1. Trigger the enemy explosion.
		Instantiate (Resources.Load ("enemyExplosion_start", typeof(GameObject)), 
					transform.position, 
					Quaternion.Euler(new Vector3(0, 0, -90)) );


		//2. Destroy this current gameobject.
		Destroy (gameObject);

	}
}
