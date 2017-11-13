using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour {

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

		//1. Trigger a fade out animation first. 
		//Then destroy this current gameobject. 
		GetComponent<Animator>().SetTrigger ("isShot");


		//Fade out before destroying the object.
		Destroy (gameObject,1);
		//Disable collision detection for this object.
		GetComponent<Collider> ().enabled = false;
		//Stop the object from moving.
		enemySpeed = 0f;


		//2. Trigger the enemy explosion.
		GameObject explosion=   (GameObject)Instantiate (Resources.Load ("enemyExplosion", typeof(GameObject)), 
														transform.position, 
														Quaternion.Euler(new Vector3(0, 0, -90)) );
		Destroy (explosion, 6);


		//3. Increase the player's skill points, in order to increase a skill level.
		GameObject.FindGameObjectWithTag("Ship").GetComponent<shipScript>().skillPointsIncreased();
	
	}
}
