using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class Objekt
{
	public string objTitel;
	public string objBeschreibung;
	public Sprite objIcon;

}

public class ArchiveList : MonoBehaviour 
{
	public List<Objekt> objList;
	public Transform inhaltPanel;
	public ArchiveList archive;
	public PoolManager buttonPool;

	// Use this for initialization
	void Start () 
	{
		HinzufügeButtons ();
	}
		

	private void HinzufügeButtons()
	{
		for (int i = 0; i < objList.Count; i++) 
		{
			Objekt obj = objList [i];
			GameObject neuButton = buttonPool.GetObject (); //objekt(button) wird von Pool geholt, active und null parent
			neuButton.transform.SetParent (inhaltPanel); //geholte objekt wird in inhaltpanel positioniert

			BeispielButton beispielButton = neuButton.GetComponent<BeispielButton> ();
			beispielButton.Setup (obj); //objekt titel,beschreibung und sprite wird zur Funktion Setup(BeispielButton.cs) geschickt. und referenz zu diesem script
		}
	}
}
