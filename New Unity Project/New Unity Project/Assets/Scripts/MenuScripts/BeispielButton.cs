using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeispielButton : MonoBehaviour 
{
	public Button button;
	public Text titel;
	public Text beschreibung;
	public Image icon;

	private Objekt obj;
	// Use this for initialization
	void Start () 
	{
		
	}

	public void Setup(Objekt gegenwartObj) //weiter gegeben von archivelist
	{
		obj = gegenwartObj;
		titel.text = obj.objTitel;
		beschreibung.text = obj.objBeschreibung;
		icon.sprite = obj.objIcon;

	}

}
