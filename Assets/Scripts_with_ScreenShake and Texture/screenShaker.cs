using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenShaker : MonoBehaviour {


	public float duration = 0.5f;
	public float magnitude= 0.5f;

	Transform myCam;

	// Use this for initialization
	void Start () {

		myCam = Camera.main.transform;

	}

	void Update()
	{
		
		if (Input.GetKeyDown (KeyCode.M))
			startBigScreenShake ();
		if (Input.GetKeyDown (KeyCode.A))
			startSmallScreenShake ();
		

	}

	void startBigScreenShake()
	{
		duration = 4f;
		magnitude = 4f;
		startScreenShake ();
		
	}

	void startSmallScreenShake()
	{
		duration = 0.1f;
		magnitude = 0.3f;
		startScreenShake ();
	}


	public void startScreenShake()
	{
		StartCoroutine ("shakeSequence");
	}

	IEnumerator shakeSequence ()
	{
		float elapsed = 0.0f;

		Vector3 originalCamPos = myCam.position;

		while (elapsed < duration) {

			elapsed += Time.deltaTime;          

			float percentComplete = elapsed / duration;         
			float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

			// map value to [-1, 1]
			//Note: the y axis is replaced with the z axis here.

			float x = Random.value * 2.0f - 1.0f;
			float z = Random.value * 2.0f - 1.0f;
			x *= magnitude * damper;
			z *= magnitude * damper;

			//Added: Making sure the shake happens -around- the original cam position.
			x += originalCamPos.x;
			z += originalCamPos.z;

			//Note the axes affected by the shake.
			Camera.main.transform.position = new Vector3(x,originalCamPos.y, z);

			yield return null;
		}

		myCam.position = originalCamPos;
	}


}
