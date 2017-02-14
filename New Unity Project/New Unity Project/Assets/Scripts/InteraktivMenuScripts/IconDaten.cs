using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
		iconDaten.SetActive (false);		
	}

	public void Daten()
	{
		daten = objekt.Beschreibung;
	}
}
