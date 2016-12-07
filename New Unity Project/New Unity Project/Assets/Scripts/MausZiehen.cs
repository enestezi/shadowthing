using UnityEngine;
using System.Collections;

public class MausZiehen : MonoBehaviour {
	private Vector2 pos;

	public void Ziehen (TargetJoint2D tj_ziehen) 
	{
		pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		tj_ziehen.target = pos;	
	}
}
