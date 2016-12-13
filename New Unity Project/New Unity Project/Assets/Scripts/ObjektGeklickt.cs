using UnityEngine;
using System.Collections;

public class ObjektGeklickt : MonoBehaviour {

	private GameObject manager;

	private MausZiehen mausZiehen;
	private MausradDreh mausradDreh;
	private TastaturController tastaturController;
	public TargetJoint2D tj_geklickt;
	public Rigidbody2D rb_geklickt;
	public Rigidbody2D rb_geklickt_interaktiv2;
	// jonas public static GameObject lastClickedObject;

	void Start ()
	{
		manager = GameObject.FindWithTag ("MainCamera");
		mausZiehen = manager.GetComponent<MausZiehen> ();
		mausradDreh = manager.GetComponent<MausradDreh> ();
		tastaturController = manager.GetComponent<TastaturController> ();

		tj_geklickt = gameObject.GetComponent<TargetJoint2D> ();
		rb_geklickt = gameObject.GetComponent<Rigidbody2D> ();

		if (gameObject.GetComponentInParent<Interaktiv1Parent> () != null) 
		{
			rb_geklickt_interaktiv2 = gameObject.GetComponentInParent<Interaktiv1Parent> ().interaktiv2.GetComponent<Rigidbody2D> ();
		}
	}
		
	void OnMouseDrag ()
	{
		mausradDreh.Rb_holen(rb_geklickt);
		tastaturController.Rb_holen (rb_geklickt_interaktiv2);
		mausZiehen.Ziehen(tj_geklickt);

		// jonas ObjektGeklickt.lastClickedObject = this.gameObject;
	}

}
