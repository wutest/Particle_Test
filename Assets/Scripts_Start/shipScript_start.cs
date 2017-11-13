using UnityEngine;
using System.Collections;

public class shipScript_start: MonoBehaviour {
	
	float speed=0.2f;

	float bullet_Xoffset=0.1f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKey(KeyCode.UpArrow) && transform.position.z<-4.5f)
			transform.Translate (new Vector3(speed, 0, 0));
		else if(Input.GetKey(KeyCode.DownArrow) && transform.position.z>-10.4f)
			transform.Translate (new Vector3(-speed, 0, 0));

		if(Input.GetKey(KeyCode.LeftArrow)  && transform.position.x>5f)
			transform.Translate (new Vector3(0, -speed, 0));
		else if(Input.GetKey(KeyCode.RightArrow)  && transform.position.x<13.2f)
			transform.Translate (new Vector3(0, speed, 0));

		if (Input.GetKeyDown (KeyCode.Space))
			shootBullet ();

	
	}

	void shootBullet()
	{
		Vector3 spawnPosition = new Vector3 (transform.position.x+bullet_Xoffset,
							 				 transform.position.y, 
							 				 transform.position.z);


		Instantiate (Resources.Load ("shipBullet_start", typeof(GameObject)), 
									 spawnPosition, 
									 Quaternion.Euler(new Vector3(90, 0, 0)) );

	}


}
