using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IconHalter : MonoBehaviour, IDropHandler  
{
	public int halterNrDrop;
	private InteraktivList intList;

	void Start ()
	{
		intList = GameObject.FindGameObjectWithTag ("menuManager").GetComponent<InteraktivList> ();
	}

	public void OnDrop (PointerEventData eventData)
	{  
		IconZiehen dropIcon = eventData.pointerDrag.GetComponent<IconZiehen> ();

		if (this.transform.childCount == 0) 
		{
			dropIcon.halterNr = halterNrDrop; //aktualisiert die halternr von icon mit nr von dem dropped halter
		} 
		else if (this.transform.childCount != 0) 
		{
			
				Transform icon = this.transform.GetChild (0);
				icon.GetComponent<IconZiehen> ().halterNr = dropIcon.halterNr;
				icon.transform.SetParent (intList.halterList [dropIcon.halterNr].transform);
				icon.transform.position = intList.halterList [dropIcon.halterNr].transform.position;

				dropIcon.halterNr = halterNrDrop;
				dropIcon.transform.SetParent (this.transform);
				dropIcon.transform.position = this.transform.position;
			
		}

	}

}
