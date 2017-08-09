using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using UnityEngine.UI;



public class InteraktivList : MonoBehaviour {

	InteraktivManager intManager;

	ObjektDatenbank objDatenbank;
	private int objAnzahl;

	public GameObject iconPanel;
	public GameObject halterPanel;

	public GameObject halter; 
	public GameObject icon; 

	public List<GameObject> halterList = new List<GameObject>();
	public List<GameObject> iconList = new List<GameObject>();

	public bool geklickt = false; //TODO: lösche

	// figur-variablen für puppen
	public Transform figurPos;
	public List<GameObject> figurPool;
	public List<GameObject> aktivFigurPool;
	public GameObject figur; 
	public GameObject aktivFigur;

	void Start()
	{
		intManager = InteraktivManager.Instance;

		objDatenbank = ObjektDatenbank.Instance;
		objAnzahl = objDatenbank.objekte.Count;

		iconPanel = GameObject.FindGameObjectWithTag ("iconPanel");
		halterPanel = GameObject.FindGameObjectWithTag ("halterPanel");
		halter = Resources.Load<GameObject> ("Prefab/Menu/Halter");
		icon = Resources.Load<GameObject> ("Prefab/Menu/FigurIcon");

		// bereite figur variablen
		figurPool = new List<GameObject>();
		figurPos = ((GameObject)GameObject.FindGameObjectWithTag ("figuren")).transform;

		int halterzahl = objAnzahl + 4; //TODO: änder das!
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

			//erzeuge figuren
			figur = (GameObject)GameObject.Instantiate (objDatenbank.objekte [i].PrefFigur);
			figur.name = figur.name.Replace("(Clone)", "");
			figurPool.Add (figur);
			figur.transform.position = figurPos.position;
			figur.transform.SetParent (figurPos);
			intManager.bereiteFiguren(); //singleton wurde in function gelagert damit es mehr als einmal afgerufen werden kann

			// wenn figurzuicon geklärt wird, muss umgezogen werden
			figur.GetComponentInChildren<ObjektGeklickt> ().iconZiehen = iconList [i].GetComponent<IconZiehen> (); //iconziehen script wird mimt dem jeweiligen objektgeklickt script gekoppelt
			figur.SetActive (false);
		}


	}
		
	public GameObject HolePoolFigur(string signatur)
	{
		for (int i = 0; i < figurPool.Count; i++) 
		{
			if (figurPool [i].name == (signatur)) //TODO:lösche "clone"
			{
				return figurPool [i];
			}
		}
		return null;
	}

	public GameObject HolePoolAktivFigur(string signatur)
	{
		for (int i = 0; i < aktivFigurPool.Count; i++) 
		{
			if (aktivFigurPool [i].name == (signatur)) //TODO:lösche "clone"
			{
				return aktivFigurPool [i];
			}
		}
		return null;
	}

	public void AktiviereFigur(string aktiviereSignatur)
	{
		aktivFigur = HolePoolFigur (aktiviereSignatur);

		if (aktivFigur == null)
			return;
		
		aktivFigurPool.Add (aktivFigur);
		aktivFigur.SetActive (true);

	}

	public void DeaktiviereFigur(string deaktiviereSignatur)
	{
		GameObject deaktiviereFigur = HolePoolAktivFigur(deaktiviereSignatur);

		if (deaktiviereFigur == null)
			return;
		
		aktivFigurPool.Remove (deaktiviereFigur);
		deaktiviereFigur.SetActive (false);
	}
		
}
