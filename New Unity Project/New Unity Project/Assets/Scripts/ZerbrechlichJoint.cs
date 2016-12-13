using UnityEngine;
using System.Collections;

public class ZerbrechlichJoint : MonoBehaviour {

	public GameObject[] interaktiv1;
	public GameObject interaktiv1FJ; //um Objekt zu lagern, das fixedjoint hat 
	public FixedJoint2D neu_fj_interaktiv1;

	private GameObject zerbrechlich;
	public InteraktivManager manager;

	public float angle;
	public bool kaputt;

	void Start () 
	{	 
		manager = InteraktivManager.Instance;
			
		zerbrechlich = gameObject.GetComponentInParent<Interaktiv1Parent> ().zerbrechlich; //GameObject.FindGameObjectWithTag ("zerbrechlichJoint");

		interaktiv1 = GameObject.FindGameObjectsWithTag ("interakiv1"); 

		for (int i = 0; i < interaktiv1.Length; ++i) 
		{
			if (interaktiv1[i].GetComponent<FixedJoint2D> () != null) 
			{
				interaktiv1FJ = interaktiv1 [i];
			}
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
				interaktiv1FJ.AddComponent<FixedJoint2D> ();
				neu_fj_interaktiv1 = interaktiv1FJ.GetComponent<FixedJoint2D> ();

				neu_fj_interaktiv1.connectedBody = zerbrechlich.GetComponent<Rigidbody2D>();
				neu_fj_interaktiv1.autoConfigureConnectedAnchor = true;
				neu_fj_interaktiv1.breakForce = 2000;
				neu_fj_interaktiv1.breakTorque = 2000;

				neu_fj_interaktiv1.anchor = manager.anchorLager;

				kaputt = false;
			}
		}
	}
}
