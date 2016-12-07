using UnityEngine;
using System.Collections;

public class ZiehenController : MonoBehaviour {

	private GameObject[] interaktiv1;
	private GameObject[] reSkin;

	private Rigidbody2D[] rb_interaktiv1;
	private TargetJoint2D[] tj_interaktiv1;

	private ObjektGeklickt[] geklickt;
	private ReSkinAnimation[] reskin;

	public Vector2 pos;
	private RaycastHit2D hit;
	public TargetJoint2D tj_zuletztGeklickt;

	void Awake ()
	{
		// alle interaktiv1 Objekte sind vorbereitet
		interaktiv1 = GameObject.FindGameObjectsWithTag ("interakiv1"); 
		geklickt = new ObjektGeklickt[interaktiv1.Length];
		tj_interaktiv1 = new TargetJoint2D[interaktiv1.Length];
		rb_interaktiv1 = new Rigidbody2D[interaktiv1.Length];

		for (int i = 0; i < interaktiv1.Length; ++i) 
		{
			if (interaktiv1 [i].GetComponent<ObjektGeklickt> () == null) 
			{
				geklickt [i] = interaktiv1 [i].AddComponent<ObjektGeklickt> ();
			}

			if (interaktiv1 [i].GetComponent<TargetJoint2D> () == null) 
			{
				tj_interaktiv1 [i] = interaktiv1[i].AddComponent<TargetJoint2D> ();
			}

			rb_interaktiv1 [i] = interaktiv1 [i].GetComponent<Rigidbody2D> ();
			tj_interaktiv1[i] = rb_interaktiv1[i].GetComponent<TargetJoint2D> ();

			rb_interaktiv1[i].freezeRotation = false;	
		}

		// alle reSkin Objekte sind vorbereitet
		reSkin = GameObject.FindGameObjectsWithTag ("reSkin");
		reskin = new ReSkinAnimation[reSkin.Length];

		for (int i = 0; i < reSkin.Length; ++i) 
		{
			if (interaktiv1 [i].GetComponent<ReSkinAnimation> () == null) 
			{
				reskin [i] = reSkin [i].AddComponent<ReSkinAnimation> ();
			}
		}
	}


	public void ZuletztGeklickt ()
	{
		pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		hit = Physics2D.Raycast(pos,Vector2.zero);

		for (int i = 0; i < interaktiv1.Length; ++i) 
		{
			if ((hit.collider.tag == "interakiv1") == interaktiv1 [i]) 
			{	
					tj_zuletztGeklickt = tj_interaktiv1 [i];

			}
		}

	}
}