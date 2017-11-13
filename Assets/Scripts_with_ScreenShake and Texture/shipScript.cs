using UnityEngine;
using System.Collections;

public class shipScript : MonoBehaviour {
	
	float speed=0.2f;
	float bullet_Xoffset=0.1f;

	int skillPoints=0;

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


		GameObject bullet= (GameObject)Instantiate (Resources.Load ("shipBullet", typeof(GameObject)), 
									 spawnPosition, 
									 Quaternion.Euler(new Vector3(90, 0, 0)) );

		Destroy (bullet, 6f);

	}

	void OnTriggerEnter(Collider other) {


		if (other.tag == "Enemy") {


			GameObject screenTexture = GameObject.FindWithTag ("screenTexture");
			screenTexture.GetComponent<Animator> ().SetTrigger ("isPlayerShot");

		}

	}

	public void skillPointsIncreased()
	{
		skillPoints++;


		//call the effect every time 3 enemies are defeated.
		if (skillPoints % 3 == 0 && skillPoints != 0) 
		{
			print ("CHANGING POSITION.");

			//find the skillText object.
			GameObject skillText=GameObject.FindGameObjectWithTag("skillText");

			//Creating some variables to transpose world to screen coordinates.
				//These are the edge of screen variables.
				float delta_shipPosX=12.88f-5.3f;
				float delta_shipPosZ= (10.39f-4.59f);
				float delta_uiTextPosX= 3.61f+2.58f;
				float delta_uiTextPosY= 2.77f+2.66f;

				float ship_shiftX = 5.3f;
				float ship_shiftZ = -4.59f;

				float UI_shiftX = -2.58f;
				float UI_shiftY = -2.66f;

			//Update the text's position;
			float newUI_PosX=(gameObject.transform.position.x-ship_shiftX)*(delta_uiTextPosX/delta_shipPosX);
			float newUI_PosY=(gameObject.transform.position.z-ship_shiftZ)*(delta_uiTextPosY/delta_shipPosZ);

		skillText.GetComponent<RectTransform> ().localPosition = new Vector3 (newUI_PosX+UI_shiftX+ 0.73f, newUI_PosY-UI_shiftY+0.1f, 0f);
			skillText.GetComponent<Animator> ().SetTrigger ("isSkillUp");
		}
	}

}
