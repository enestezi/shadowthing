using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ArchiveList : MonoBehaviour 
{
	ObjektManager objManager;

	public struct Objekt
	{
		public string objTitel;
		public string objBeschreibung;
		public Sprite objIcon;
	}

	public List<Objekt> objList;

	public Transform inhaltPanel;
	public GameObject beispielButton;

	Objekt obj;
	// Use this for initialization
	void Start () 
	{
		objManager = ObjektManager.Instance;
		objList = new List<Objekt>();
		beispielButton = Resources.Load<GameObject> ("Prefab/Menu/BeispielButton");
		HinzufügeList ();

	}
	public void HinzufügeList()
	{
		
		for (int i = 0; i < objManager.objektSignatur.Count; i++) {
			
			obj.objTitel = objManager.objektSignatur [i];
			obj.objBeschreibung = objManager.objektSignatur [i];
			obj.objIcon = Resources.Load<Sprite> ("Sprites/Thumbnails/" + objManager.objektSignatur [i]);
			objList.Add (obj);

}

		foreach (Objekt obj in objList) {
			GameObject neuButton = Instantiate (beispielButton) as GameObject;
			BeispielButton button = neuButton.GetComponent<BeispielButton> ();
			button.icon.sprite = obj.objIcon;
			button.titel.text = obj.objTitel;
			button.beschreibung.text = obj.objBeschreibung;
			neuButton.transform.SetParent (inhaltPanel);
		}

	}
}
