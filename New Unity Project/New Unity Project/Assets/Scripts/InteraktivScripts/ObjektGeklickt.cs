using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

// Script für Finden der geklickten Objekte
public class ObjektGeklickt : MonoBehaviour {

	private GameObject manager;

	private MausZiehen mausZiehen;
	private MausradDreh mausradDreh;
	private TastaturController tastaturController;
	private BoxCollider2D hintergrundMenu;

	public TargetJoint2D tj_geklickt;
	public Rigidbody2D rb_geklickt;
	public Rigidbody2D rb_geklickt_interaktiv2;

	public IconZiehen iconZiehen; //siehe interaktivList

	// jz public static GameObject lastClickedObject;

	void Start ()
	{
		manager = GameObject.FindWithTag ("MainCamera");	// TODO muss ein leeres GameObjekt erzeugt werden, um monobehavior scripts zu lagern
		mausZiehen = manager.GetComponent<MausZiehen> ();
		mausradDreh = manager.GetComponent<MausradDreh> ();
		tastaturController = manager.GetComponent<TastaturController> ();
		hintergrundMenu = GameObject.FindGameObjectWithTag ("hintergrund").GetComponent<BoxCollider2D>();
		hintergrundMenu.enabled = false;

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

		// TODO: if menu is on
		hintergrundMenu.enabled = true;

		// jz ObjektGeklickt.lastClickedObject = this.gameObject;
	}

	void OnMouseUp ()
	{
		// TODO: if menu is on
		hintergrundMenu.enabled = false;
	}

	void OnTriggerEnter2D (Collider2D other) 
	{
		if (other.gameObject.CompareTag("hintergrund")) 
		{
			this.gameObject.SetActive (false);

			iconZiehen.OnDrag (iconZiehen.data); //eventData wird zurückgeschickt, da die funktion es braucht
		}
	}

}
