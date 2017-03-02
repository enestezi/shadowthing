using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

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
	public GameObject figur; 
	public GameObject deaktivierFigur = null;

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
			figurPool.Add (figur);
			figur.transform.position = figurPos.position;
			figur.transform.SetParent (figurPos);
			figur.SetActive (false);
		}


	}
		
	public GameObject HolePoolFigur(string signatur)
	{
		for (int i = 0; i < figurPool.Count; i++) 
		{
			if (figurPool [i].name == (signatur+"(Clone)")) //TODO:lösche clone
			{
				return figurPool [i];
			}
		}
		return null;
	}

	public void AktiviereFigur(string aktivSignatur)
	{
		GameObject aktivFigur = HolePoolFigur (aktivSignatur);

		if (aktivFigur == null)
			return;
		if (deaktivierFigur)
			deaktivierFigur.SetActive (false); // Deaktiviere aktiven Figur

		aktivFigur.SetActive (true);
		intManager.bereiteFiguren(); //singleton wurde in function gelagert damit es mehr als einmal afgerufen werden kann
		deaktivierFigur = aktivFigur;
	}


	public void zuruck(){
		Debug.Log ("sfdad");
		SceneManager.LoadScene (0);
	}
}
