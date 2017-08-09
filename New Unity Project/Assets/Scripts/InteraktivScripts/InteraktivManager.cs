﻿using UnityEngine;
using System.Collections;


//Manager für bewegliche Objekte
public class InteraktivManager  
{
	private GameObject[] interaktiv1;				//primaer bewegbare  Objekte (mauskontroll)
	private GameObject[] reSkin;					//Kontainer von puppen. es wird für Texturänderungen, Kinderelemente Finden und Center of Mass Festlegen benutzt 

	private TargetJoint2D[] tj_interaktiv1;			//TargetJoint2D's von primaer bewegbare  Objekte, die hier hinzugefügt wird

	//scripts zum Hinzufügen
	private ObjektGeklickt[] geklickt;				
	private ReSkinAnimation[] reskin;
	private Interaktiv1Parent[] interaktiv1Parent;  //script um von FixedJoint2D betroffene Objekte zu finden

	// FixedJoint2D und sen Anchor zum Einstellen und wiedererzeugen
	public FixedJoint2D fj_interaktiv1;
	public Vector2 anchorLager;

	// Center of Mass
	private Rigidbody2D[] rb_all;
	public PolygonCollider2D[] pc_all;
	public Vector2[] CoMLager;
	public float[] MassLager; 

	//Singleton
	private static InteraktivManager instance;
	public static InteraktivManager Instance
	{
		get {
			if (instance == null)
				instance = new InteraktivManager ();
			return instance;
		}
	}
		

	public void bereiteFiguren()
	{
		// alle interaktiv1 Objekte sind vorbereitet
		interaktiv1 = GameObject.FindGameObjectsWithTag ("interakiv1"); 
		geklickt = new ObjektGeklickt[interaktiv1.Length];
		tj_interaktiv1 = new TargetJoint2D[interaktiv1.Length];


		for (int i = 0; i < interaktiv1.Length; ++i) //gehe durch alle primaer bewegbare Objekte und hinzufügt ...
		{
			if (interaktiv1 [i].GetComponent<TargetJoint2D> () != null)
				return;
			
				tj_interaktiv1 [i] = interaktiv1[i].AddComponent<TargetJoint2D> ();
				geklickt [i] = interaktiv1 [i].AddComponent<ObjektGeklickt> ();
		}

		// alle reSkin Objekte sind vorbereitet
		reSkin = GameObject.FindGameObjectsWithTag ("reSkin");
		reskin = new ReSkinAnimation[reSkin.Length];
		interaktiv1Parent = new Interaktiv1Parent[reSkin.Length];
		pc_all = new PolygonCollider2D[reSkin.Length];
		CoMLager = new Vector2[reSkin.Length];
		MassLager = new float[reSkin.Length];

		for (int i = 0; i < reSkin.Length; ++i) 
		{
			if (reSkin [i].GetComponent<ReSkinAnimation> () != null)
				return;
			
				reskin [i] = reSkin [i].AddComponent<ReSkinAnimation> ();


			if (reSkin [i].GetComponentInChildren<FixedJoint2D> () != null) // wenn FixedJoint2D da ist:
			{
				interaktiv1Parent [i] = reSkin [i].AddComponent<Interaktiv1Parent> ();

				fj_interaktiv1 = reSkin [i].GetComponentInChildren<FixedJoint2D> ();
				fj_interaktiv1.autoConfigureConnectedAnchor = true;
				fj_interaktiv1.breakForce = 2000;
				fj_interaktiv1.breakTorque = 2000;

				anchorLager = fj_interaktiv1.anchor; // anchor lagern um fixed joint von der stelle wieder zu erstellen
			}

			// Center of Mass
			rb_all = reSkin [i].GetComponentsInChildren<Rigidbody2D>();

			foreach (Rigidbody2D tb in rb_all) 
			{
				// disable alle collider damit denen gewicht nicht mit gerechnet wird
//				tb.gameObject.GetComponent<Collider2D> ().enabled = false;

				//hinzufüge PolygonCollider2D
				pc_all [i] = tb.gameObject.AddComponent<PolygonCollider2D> ();	
				pc_all [i] = tb.gameObject.GetComponent<PolygonCollider2D> ();	

				//Debug.Log ("old mass" + tb.mass );

				// hole Masse, die mit hilfe der existierenden colliders (Polygon) automatisch berechnet wird
//				tb.useAutoMass = true;
//				MassLager [i] = tb.mass;
//				tb.useAutoMass = false;
//				tb.mass = MassLager [i];
//
				//hole von PolygonCollider2D erzeugte CoM
				CoMLager [i] = tb.centerOfMass;									
				UnityEngine.Object.Destroy(pc_all [i]);	//zerstöre alle PolygonCollider2D's, sie sind nicht mehr nötig						
				tb.centerOfMass = CoMLager [i];	//setze gespeicherte CoM's, die von PolygonCollider erzeugt worden sind, als Rigidbody2D's CoM 

				// enable alle collider damit denen gewicht nicht mit gerechnet wird
//				tb.gameObject.GetComponent<Collider2D> ().enabled = true;

				//Debug.Log ("new mass" + tb.mass );
				//Debug.Log (tb.gameObject.name + CoMLager[i] + tb.centerOfMass);

			}

		}
	}
}