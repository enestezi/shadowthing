using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ArchiveList : MonoBehaviour 
{
	InteraktivManager intManager;
	ObjektManager objManager;

	public struct Objekt
	{
		public string objTitel;
		public string objBeschreibung;
		public Sprite objIcon;
	}
	Objekt obj;

	public List<Objekt> objList;
	public int objAnzahl = 0;


	//content panel and button
	public Transform inhaltPanel;
	public GameObject beispielButton;

	// figur-variablen für puppen
	public Transform figurPos;
	public List<GameObject> figurPool;
	public GameObject figur; 
	public GameObject deaktivierFigur = null;


	// Use this for initialization
	void Start () 
	{
		objManager = ObjektManager.Instance;
		intManager = InteraktivManager.Instance;
		figurPool = new List<GameObject>();
		objList = new List<Objekt>();
		objAnzahl = objManager.objektSignatur.Count;
		beispielButton = Resources.Load<GameObject> ("Prefab/Menu/BeispielButton");
		inhaltPanel = ((GameObject)GameObject.FindGameObjectWithTag ("inhaltPanel")).transform;
		figurPos = ((GameObject)GameObject.FindGameObjectWithTag ("figuren")).transform;
		HinzufügeObj ();
	}
		
	public void HinzufügeObj()
	{
		for (int i = 0; i < objAnzahl; i++)
		{
			string dataSignaturListe;
			dataSignaturListe = objManager.objektSignatur [i];

			obj.objTitel = dataSignaturListe;
			obj.objBeschreibung = dataSignaturListe;
			obj.objIcon = Resources.Load<Sprite> ("Sprites/Thumbnails/" + dataSignaturListe);
			objList.Add (obj);

			// Figuren instantiate und in pool hinzugefügt
			figur = (GameObject)GameObject.Instantiate (Resources.Load<GameObject>("Prefab/Interaktiv/"+dataSignaturListe));
			figurPool.Add (figur);
			figur.transform.position = figurPos.position;
			figur.transform.SetParent (figurPos);
			figur.SetActive (false);

			GameObject neuButton = Instantiate (beispielButton) as GameObject;
			BeispielButton button = neuButton.GetComponent<BeispielButton> ();
			button.icon.sprite = objList[i].objIcon;
			button.titel.text = objList[i].objTitel;
			button.beschreibung.text = objList[i].objBeschreibung;
			neuButton.transform.SetParent (inhaltPanel);

			neuButton.GetComponent<Button> ().onClick.AddListener (() => {AktiviereFigur(dataSignaturListe);});
		    //vielleicht neue for schleife?? wird aktiviereFigur nur letzte inaktive gameobjekt weiter gegeben
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
		
		Debug.Log (aktivSignatur);
		Debug.Log (aktivFigur+"obj");
		aktivFigur.SetActive (true);
		intManager.bereiteFiguren(); //singleton wurde in function gelagert damit es mehr als einmal afgerufen werden kann
		deaktivierFigur = aktivFigur;
	}
}
