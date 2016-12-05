using UnityEngine;
using System.Collections;

public class ZiehenController : MonoBehaviour {

	private GameObject interaktiv1;
	private GameObject reSkin;
	private Vector3 pos;
		
	public bool rigidbodyDreh; // why lil buggy???---

	private Rigidbody2D rb_interaktiv1;

	void Start ()
	{
		interaktiv1 = GameObject.FindWithTag ("interakiv1"); // must made with findgameobjectswithtag
		reSkin = GameObject.FindWithTag ("reSkin");

		interaktiv1.AddComponent<ObjektGeklickt> ();
		reSkin.AddComponent<ReSkinAnimation> ();

		rb_interaktiv1 = interaktiv1.GetComponent<Rigidbody2D> ();

		interaktiv1.GetComponent<Rigidbody2D>().freezeRotation = false;
		rigidbodyDreh = false;

		if (interaktiv1.GetComponent<TargetJoint2D>() == null)
			interaktiv1.AddComponent<TargetJoint2D>();
	}
		
	void Update ()
	{
		if (Input.GetMouseButton (1)) 
		{
			if (!rigidbodyDreh) 
			{
				rb_interaktiv1.freezeRotation = true;
				rigidbodyDreh = true;
			} 
			else 
			{
				rb_interaktiv1.freezeRotation = false;
				rigidbodyDreh = false;
			}
		}
	}

	public void Drag ()
	{
		pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		interaktiv1.GetComponent<TargetJoint2D> ().target = pos;
	}
	

}