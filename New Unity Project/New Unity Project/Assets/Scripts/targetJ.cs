using UnityEngine;
using System.Collections;

public class targetJ : MonoBehaviour {

		void OnEnable ()
		{
		if (GetComponent<TargetJoint2D>() == null)
			gameObject.AddComponent<TargetJoint2D>();
		}

		// Update is called once per frame
		void FixedUpdate ()
		{
			while (Input.GetMouseButton (0)) 
			{
				var worldPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				GetComponent<TargetJoint2D> ().target = worldPos;
			}
		}
	}