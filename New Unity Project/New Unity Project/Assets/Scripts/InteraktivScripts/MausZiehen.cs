using UnityEngine;
using System.Collections;

// Script für Dragging
public class MausZiehen : MonoBehaviour {

	private Vector2 pos; // Lager für Mausposition


	// hole TargetJoint2D und setzt sein Target auf Mausposition
	public void Ziehen (TargetJoint2D tj_ziehen) 
	{
		pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		tj_ziehen.target = pos;	
	}
}
