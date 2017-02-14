﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class InteraktivList : MonoBehaviour {

	ObjektDatenbank objDatenbank;
	private int objAnzahl;

	public GameObject figurenPanel;
	public GameObject halterPanel;

	public GameObject halter; 
	public GameObject icon; 

	public List<GameObject> halterList = new List<GameObject>();
	public List<GameObject> iconList = new List<GameObject>();

	public bool geklickt = false;

	void Start()
	{
		objDatenbank = ObjektDatenbank.Instance;
		objAnzahl = objDatenbank.objekte.Count;

		figurenPanel = GameObject.FindGameObjectWithTag ("iconPanel");
		halterPanel = GameObject.FindGameObjectWithTag ("halterPanel");
		halter = Resources.Load<GameObject> ("Prefab/Menu/Halter");
		icon = Resources.Load<GameObject> ("Prefab/Menu/FigurIcon");

		int halterzahl = objAnzahl + 4; //änder das!
		for (int i = 0; i < halterzahl; i++) 
		{
			halterList.Add (Instantiate (halter));
			halterList[i].transform.SetParent (halterPanel.transform);
			halterList [i].GetComponent<IconHalter> ().halterNrDrop = i; //halter bekommt jeweiligen halternummer
		}

		for (int i = 0; i < objAnzahl; i++) 
		{
			


			iconList.Add (Instantiate (icon));
			iconList [i].GetComponent<IconZiehen> ().objekt = objDatenbank.objekte [i]; //objektdaten script von icon bekommt jeweiligen objekt(infos)
			iconList [i].GetComponent<IconZiehen> ().halterNr = i;	//icon bekommt jeweiligen haternummer
			iconList[i].transform.SetParent (halterList[i].transform);
			iconList [i].transform.position = Vector2.zero;
			iconList [i].GetComponent<Image> ().sprite = objDatenbank.objekte [i].Icon;

		}


	}
		
	public void zuruck(){
		Debug.Log ("sfdad");
		SceneManager.LoadScene (0);
	}
}
