using UnityEngine;
using System.Collections;

public class InteraktivManager  
{
	private GameObject[] interaktiv1;
	private GameObject[] reSkin;

	private TargetJoint2D[] tj_interaktiv1;

	private ObjektGeklickt[] geklickt;
	private ReSkinAnimation[] reskin;
	private Interaktiv1Parent[] interaktiv1Parent;

	public FixedJoint2D fj_interaktiv1;
	public Vector2 anchorLager;

	private static InteraktivManager instance;
	public static InteraktivManager Instance
	{
		get {
			if (instance == null)
				instance = new InteraktivManager ();
			return instance;
		}
	}

	public InteraktivManager()
	{
		// alle interaktiv1 Objekte sind vorbereitet
		interaktiv1 = GameObject.FindGameObjectsWithTag ("interakiv1"); 
		geklickt = new ObjektGeklickt[interaktiv1.Length];
		tj_interaktiv1 = new TargetJoint2D[interaktiv1.Length];


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
				
		}

		// alle reSkin Objekte sind vorbereitet
		reSkin = GameObject.FindGameObjectsWithTag ("reSkin");
		reskin = new ReSkinAnimation[reSkin.Length];
		interaktiv1Parent = new Interaktiv1Parent[reSkin.Length];

		for (int i = 0; i < reSkin.Length; ++i) 
		{
			if (reSkin [i].GetComponent<ReSkinAnimation> () == null) 
			{
				reskin [i] = reSkin [i].AddComponent<ReSkinAnimation> ();
			}

			if (reSkin [i].GetComponentInChildren<FixedJoint2D> () != null)
			{
				interaktiv1Parent [i] = reSkin [i].AddComponent<Interaktiv1Parent> ();

				fj_interaktiv1 = reSkin [i].GetComponentInChildren<FixedJoint2D> ();
				fj_interaktiv1.autoConfigureConnectedAnchor = true;
				fj_interaktiv1.breakForce = 2000;
				fj_interaktiv1.breakTorque = 2000;

				anchorLager = fj_interaktiv1.anchor; // anchor lagern um fixed joint von der stelle wieder zu erstellen
			}
		}
	}
}