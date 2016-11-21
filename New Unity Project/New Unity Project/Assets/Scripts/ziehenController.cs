using UnityEngine;
using System.Collections;

public class ziehenController : MonoBehaviour {

	private GameObject interaktiv1;
	private Vector3 pos;
		
	public bool rigidbodyDreh; //lil buggy---

	void Start ()
	{
		interaktiv1 = GameObject.FindWithTag ("interakiv1");
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
					interaktiv1.GetComponent<Rigidbody2D> ().freezeRotation = true;
					rigidbodyDreh = true;
				} 
				else
				{
					interaktiv1.GetComponent<Rigidbody2D>().freezeRotation = false;
					rigidbodyDreh = false;
				}
			}
			
		if (Input.GetMouseButton (0))
		{
			pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			interaktiv1.GetComponent<TargetJoint2D> ().target = pos;
		}
		}
	}