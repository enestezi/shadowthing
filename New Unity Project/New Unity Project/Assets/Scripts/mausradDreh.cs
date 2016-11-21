using UnityEngine;
using System.Collections;

public class mausradDreh : MonoBehaviour {

	private GameObject interaktiv1;

	void Start () {
		interaktiv1 = GameObject.FindWithTag ("interakiv1");

		if (interaktiv1.GetComponent<HingeJoint>()) {
			interaktiv1 = interaktiv1.AddComponent<HingeJoint2D> () as HingeJoint2D;
			GetComponent<HingeJoint>().connectedBody = interaktiv1.GetComponent<Rigidbody2D>();

		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
