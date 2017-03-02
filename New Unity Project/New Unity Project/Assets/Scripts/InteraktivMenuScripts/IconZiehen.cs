using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

//Objektdaten on icon
public class IconZiehen : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
	public LidoObjekt objekt;
	public int halterNr;	//welche halter ist das objekt in


	private InteraktivList intList;
	private IconDaten iconDaten;

	private Vector3 iconPos; 

	void Start () 
	{
		intList = GameObject.FindGameObjectWithTag ("menuManager").GetComponent<InteraktivList> ();
		iconDaten = intList.GetComponent<IconDaten> ();


	}

	public void OnBeginDrag (PointerEventData eventData)
	{
		if (objekt != null) 
		{
			iconDaten.DeaktiviereDaten ();
			this.transform.SetParent (this.transform.parent.parent); //beim drag wird die icon als kind element von eltern von eltern element gesetzt, damit es nicht hinter andere objekte bleibt
			this.transform.position = eventData.position;
			GetComponent<CanvasGroup> ().blocksRaycasts = false;
		}
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (objekt != null) 
		{
			this.transform.position = eventData.position;


		}
	}

	public void OnEndDrag(PointerEventData eventData)	
	{
		this.transform.SetParent (intList.halterList [halterNr].transform);	// nach drag zurück zum ursprungliche parent
		this.transform.position = intList.halterList [halterNr].transform.position;
		GetComponent<CanvasGroup> ().blocksRaycasts = true;
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Right)
		{
			// TODO: lastpress ist immer null. warum??
			if (eventData.pointerPress != eventData.lastPress)
			{
				iconDaten.DeaktiviereDaten ();
				iconDaten.AktiviereDaten (objekt);
				iconDaten.iconDaten.transform.SetParent (this.transform.parent);
				Vector3 iconDatenPos = this.transform.position;
				iconDatenPos.x = iconDatenPos.x - 60;
				iconDatenPos.y = iconDatenPos.y + 80;
				iconDaten.iconDaten.transform.position = iconDatenPos;
			} 
		}
			
	}

	void FixedUpdate ()
	{
		iconPos = this.transform.position;
		Debug.Log(iconPos.y);
		if (iconPos.y >= 200) 
		{
			intList.AktiviereFigur (objekt.Signatur);
		}
	}
}
