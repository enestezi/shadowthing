using UnityEngine;
using System.Collections;

public class ObjektGeklickt : MonoBehaviour {

	private ZiehenController drag;

	void OnMouseDrag ()
	{
		drag = FindObjectOfType<ZiehenController>();
		drag.Drag ();
	}
}
