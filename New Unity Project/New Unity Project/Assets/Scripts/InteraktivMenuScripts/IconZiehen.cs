using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

//Objektdaten on icon
public class IconZiehen : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler 
{
	public LidoObjekt objekt;
	public int halterNr;	//welche halter ist das objekt in

	private InteraktivList intList;

	void Start () 
	{
		intList = GameObject.FindGameObjectWithTag ("menuManager").GetComponent<InteraktivList> ();
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if (objekt != null) 
		{
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
}
