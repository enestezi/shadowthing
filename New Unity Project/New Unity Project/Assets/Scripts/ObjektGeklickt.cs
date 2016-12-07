using UnityEngine;
using System.Collections;

public class ObjektGeklickt : MonoBehaviour {

	private GameObject manager;

	private MausZiehen mausZiehen;
	private MausradDreh mausradDreh;

	public TargetJoint2D tj_geklickt;
	public Rigidbody2D rb_geklickt;

	public static GameObject lastClickedObject;

	void Start ()
	{
		manager = GameObject.FindWithTag ("MainCamera");
		mausZiehen = manager.GetComponent<MausZiehen> ();
		mausradDreh = manager.GetComponent<MausradDreh> ();

		tj_geklickt = gameObject.GetComponent<TargetJoint2D> ();
		rb_geklickt = gameObject.GetComponent<Rigidbody2D> ();
	}
		
	void OnMouseDrag ()
	{
		mausradDreh.Rb_holen(rb_geklickt);
		mausZiehen.Ziehen(tj_geklickt);

		ObjektGeklickt.lastClickedObject = this.gameObject;
	}

}
