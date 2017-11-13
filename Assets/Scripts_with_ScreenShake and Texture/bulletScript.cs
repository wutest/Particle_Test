using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour {

	public float bulletSpeed=0.1f;

	// Use this for initialization
	void Start () {

		//Destroy the bullet after 8 seconds.
		Destroy (gameObject, 8);

	}
	
	// Update is called once per frame
	void Update () {
	
		transform.Translate (new Vector3(bulletSpeed, 0, 0));

	}
		

//	void OnTriggerEnter(Collider other) {
	void OnCollisionEnter(Collision collision){
		
		if (collision.gameObject.tag == "Enemy") {

			//1.Trigger the 'enemy explosion particle'.
			collision.gameObject.GetComponent<enemyScript>().enemyDefeated();

			//2.This bullet is also destroyed
			bulletSpeed=0;
			gameObject.GetComponent<Rigidbody> ().Sleep ();


			//3. Trigger a fade out animation. 
			//Then destroy this current gameobject. 
			GetComponent<Animator>().SetTrigger ("isShot");
			//Fade out before destroying the object.
			Destroy (gameObject,1);
		

			//4.Shake the screen.
			GameObject camera= GameObject.FindWithTag("MainCamera");
			//camera.GetComponent<screenShaker> ().startScreenShake ();
			camera.GetComponent<perlinShake> ().startPerlinShake (2);

			}
		
		
		}


}
