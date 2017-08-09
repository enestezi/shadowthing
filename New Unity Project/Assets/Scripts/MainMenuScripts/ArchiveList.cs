using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ArchiveList : MonoBehaviour 
{
	InteraktivManager intManager; //ruft die funktion bereitefiguren auf, die die figuren mit scripts und componenten dekoriert
	ObjektDatenbank objDatenbank;

	private int objAnzahl = 0;


	//content panel and button
	public GameObject inhaltPanel;
	public GameObject beispielButton;

	// figur-variablen für puppen
	public Transform figurPos;
	public List<GameObject> figurPool;
	public GameObject figur; 
	public GameObject deaktivierFigur = null;


	// Use this for initialization
	void Start () 
	{
		objDatenbank = ObjektDatenbank.Instance;
		objAnzahl = objDatenbank.objekte.Count;

		intManager = InteraktivManager.Instance;

		figurPool = new List<GameObject>();
		beispielButton = Resources.Load<GameObject> ("Prefab/Menu/BeispielButton");
		inhaltPanel = ((GameObject)GameObject.FindGameObjectWithTag ("inhaltPanel"));
		figurPos = ((GameObject)GameObject.FindGameObjectWithTag ("figuren")).transform;
		HinzufügeObj ();
	}
		
	public void HinzufügeObj()
	{
		for (int i = 0; i < objAnzahl; i++)
		{
			GameObject neuButton = Instantiate (beispielButton) as GameObject; //TODO: was ist unterschied:(GameObject)GameObject.Instantiate (Resources.Load<GameObject>("Prefab/Interaktiv/"+dataSignaturListe)) 
			BeispielButton button = neuButton.GetComponent<BeispielButton> ();
			button.icon.sprite = objDatenbank.objekte [i].Icon;
			button.titel.text = objDatenbank.objekte [i].Titel;
			button.beschreibung.text = objDatenbank.objekte [i].Beschreibung;
			neuButton.transform.SetParent (inhaltPanel.transform);

			string objSignatur;
			objSignatur = objDatenbank.objekte [i].Signatur;
			neuButton.GetComponent<Button> ().onClick.AddListener (() => {AktiviereFigur(objSignatur);});

			// Figuren instantiate und in pool hinzugefügt
			figur = (GameObject)GameObject.Instantiate (objDatenbank.objekte [i].PrefFigur);
			figur.name = figur.name.Replace("(Clone)", "");
			figurPool.Add (figur);
			figur.transform.position = figurPos.position;
			figur.transform.SetParent (figurPos);
			intManager.bereiteFiguren(); //singleton wurde in function gelagert damit es mehr als einmal afgerufen werden kann
			figur.SetActive (false);
		}
	}

	public GameObject HolePoolFigur(string signatur)
	{
		for (int i = 0; i < figurPool.Count; i++) 
		{
			if (figurPool [i].name == (signatur)) //TODO:lösche clone
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
		deaktivierFigur = aktivFigur;
	}
}
