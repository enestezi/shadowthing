using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class InteraktivList : MonoBehaviour {

	public GameObject figurenPanel;
	public GameObject halterPanel;
	public GameObject halter; //in editor gesetzt
	public GameObject figurIcon; //in Editor gesetzt

	ObjektManager objManager;
	private int halterAnzahl; // das muss mit anzahl der objekte getauscht werden objList.count

	// public List<Objekt> objList = new list ... ; existiert noch nicht
	public List<GameObject> halterList = new List<GameObject>();

	void Start()
	{
		objManager = ObjektManager.Instance;
		halterAnzahl = objManager.objektSignatur.Count;

		figurenPanel = GameObject.FindGameObjectWithTag ("iconPanel");
		halterPanel = GameObject.FindGameObjectWithTag ("halterPanel");
		halter = Resources.Load<GameObject> ("Prefab/Menu/Halter");

		for (int i = 0; i < halterAnzahl; i++) 
		{
			halterList.Add (Instantiate (halter));
			halterList [i].transform.SetParent (halterPanel.transform);
		}


	}

	public void Hinzufüge()
	{}
}
