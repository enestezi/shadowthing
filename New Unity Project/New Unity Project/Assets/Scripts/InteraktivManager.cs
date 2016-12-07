using UnityEngine;
using System.Collections;

public class InteraktivManager  
{
	private static InteraktivManager instance;
	public static InteraktivManager Instance
	{
		get {
			if (instance == null)
				instance = new InteraktivManager ();
			return instance;
		}
	}

	private GameObject[] interaktiv1;
	private GameObject[] reSkin;


	private TargetJoint2D[] tj_interaktiv1;

	private ObjektGeklickt[] geklickt;
	private ReSkinAnimation[] reskin;




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

		for (int i = 0; i < reSkin.Length; ++i) 
		{
			if (interaktiv1 [i].GetComponent<ReSkinAnimation> () == null) 
			{
				reskin [i] = reSkin [i].AddComponent<ReSkinAnimation> ();
			}
		}
	}
}