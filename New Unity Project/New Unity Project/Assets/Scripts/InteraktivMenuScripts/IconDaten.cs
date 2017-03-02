using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconDaten : MonoBehaviour {

	private LidoObjekt objekt;
	private string daten;

	public GameObject iconDaten;

	void Start ()
	{
		iconDaten = GameObject.FindGameObjectWithTag ("iconDaten");
		iconDaten.SetActive (false);
	}

	public void AktiviereDaten(LidoObjekt objekt)
	{
		this.objekt = objekt;
		Daten ();
		iconDaten.SetActive (true);
	}

	public void DeaktiviereDaten ()
	{
		// wenn icon daten panel aktiviert wird, wird panel als kind element von entsprechenden halter (den halter, auf dem das Icon gedropped wird) gesetzt.
		// hier wird iconDaten-Panel als kind element von menumanager gesetzt, wenn es jedesmal deaktiviert wird, damit den halter leer bleibt und damit das Icon auf dem halter gedroppt werden kann.
		iconDaten.SetActive (false);
		iconDaten.transform.SetParent (this.transform); 
	}

	public void Daten()
	{
		daten = objekt.InhBeschreibung;
		iconDaten.transform.GetChild(0).GetComponent<Text>().text = daten;
	}

}
