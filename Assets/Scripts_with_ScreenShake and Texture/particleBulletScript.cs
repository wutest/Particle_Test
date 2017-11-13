using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleBulletScript : MonoBehaviour {


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.A)) 
		{
			//_Added this to test Github update.
			//Emit particles from the emitter.
			GetComponent<ParticleSystem>().Emit(1);
		}
	}


	void OnParticleCollision(GameObject other) {

	
		if (other.tag == "Enemy") {

			//1.Trigger the 'enemy explosion particle'.
			other.gameObject.GetComponent<enemyScript>().enemyDefeated();

			//3. Trigger a fade out animation. 
			//This object is destroyed automatically.

			//4.Shake the screen.
			GameObject camera= GameObject.FindWithTag("MainCamera");
			//camera.GetComponent<screenShaker> ().startScreenShake ();
			camera.GetComponent<perlinShake> ().startPerlinShake (2);

		}


	}


}
	
