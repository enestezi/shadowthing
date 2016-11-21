using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour {

	private float mausradDreh;        //stores the rotation of the mouse wheel
	private float geschwindigkeit = 10000.0f;      //multiplier for the mouse wheel input
	private Vector3 objPos; //stores the rotation of the attached gameObject

	private GameObject interaktiv1Dreh;
	// Use this for initialization
	void Start () 
	{ 
		interaktiv1Dreh = GameObject.FindWithTag ("interakiv1");
		objPos = interaktiv1Dreh.transform.eulerAngles;  //keeps storePos up to date 
	}

	// Update is called once per frame
	void Update () {

		mausradDreh = Input.GetAxis("Mouse ScrollWheel") * geschwindigkeit * Time.deltaTime;          


		if (mausradDreh != 0)
		{
			GetComponent<Rigidbody2D>().freezeRotation = false;
			objPos= new Vector3(objPos.x, objPos.y, objPos.z+mausradDreh);
			interaktiv1Dreh.transform.eulerAngles = objPos;
		}
	}
}