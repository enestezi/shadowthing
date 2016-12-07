using UnityEngine;
using System.Collections;

public class ObjektGeklickt : MonoBehaviour {

	private ZiehenController drag;

	void Start ()
	{
		drag = FindObjectOfType<ZiehenController>();
	}

	void OnMouseDown ()
	{
		drag.ZuletztGeklickt();
	}

	void OnMouseUp ()
	{
		drag.tj_zuletztGeklickt = null;
	}

	void OnMouseDrag ()
	{
		if (drag.tj_zuletztGeklickt != null) 
		{
			drag.pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			drag.tj_zuletztGeklickt.target = drag.pos;
		}
	}
}
