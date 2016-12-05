using UnityEngine;
using System.Collections;

public class ZerbrechlichJoint : MonoBehaviour {

	private Vector2 lagerAnchor;

	private GameObject interaktiv1;
	private FixedJoint2D joint;

	private GameObject zerbrechlich;
	public float angle;


	public bool kaputt;

	void Start () 
	{
		interaktiv1 = GameObject.FindWithTag ("interakiv1");
		joint = interaktiv1.GetComponent<FixedJoint2D> ();

		joint.autoConfigureConnectedAnchor = true;
		joint.breakForce = 3000;
		joint.breakTorque = 3000;

		lagerAnchor = joint.anchor;

		zerbrechlich = GameObject.FindGameObjectWithTag ("zerbrechlichJoint");


		kaputt = false;
	}

	void OnJointBreak2D (Joint2D brokenJoint) {
		kaputt = true;
		//Debug.Log ("Joint kaputt!");
		//Debug.Log ("force = " + brokenJoint.reactionForce);
		//Debug.Log ("torque = " + brokenJoint.reactionTorque);
	}

	void Update () 
	{
		angle = zerbrechlich.GetComponent<HingeJoint2D> ().jointAngle;
		if (kaputt) 
		{
			if (angle <= 0) 
			{
				interaktiv1.AddComponent<FixedJoint2D> ();
				joint = interaktiv1.GetComponent<FixedJoint2D> ();

				joint.connectedBody = zerbrechlich.GetComponent<Rigidbody2D>();
				joint.autoConfigureConnectedAnchor = true;
				joint.breakForce = 3000;
				joint.breakTorque = 3000;

				joint.anchor = lagerAnchor;

				kaputt = false;
			}
		}
	}
}
