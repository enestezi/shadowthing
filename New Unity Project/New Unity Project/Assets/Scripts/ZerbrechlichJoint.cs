using UnityEngine;
using System.Collections;

public class ZerbrechlichJoint : MonoBehaviour {



	private GameObject interaktiv1;

	private GameObject zerbrechlich;
	public InteraktivManager manager;

	public float angle;
	public bool kaputt;

	public FixedJoint2D joint;
	public Vector2 lagerAnchor;

	void Start () 
	{
		interaktiv1 = GameObject.FindWithTag ("interakiv1");
		 
		manager = InteraktivManager.Instance;
			
		zerbrechlich = gameObject.GetComponentInParent<Puppe> ().zerbrechlich; //GameObject.FindGameObjectWithTag ("zerbrechlichJoint");

		if (interaktiv1.GetComponent<FixedJoint2D> () != null) 
		{
			joint = interaktiv1.GetComponent<FixedJoint2D> ();
			joint.autoConfigureConnectedAnchor = true;
			joint.breakForce = 2000;
			joint.breakTorque = 2000;

			lagerAnchor = joint.anchor;

		}
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
		if (zerbrechlich) 
		{
			angle = zerbrechlich.GetComponent<HingeJoint2D> ().jointAngle;
		}

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
