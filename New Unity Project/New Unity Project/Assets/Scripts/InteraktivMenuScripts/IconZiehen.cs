using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

//Objektdaten on icon
public class IconZiehen : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler 
{
	public LidoObjekt objekt;

	private Transform iconParent;


	public void OnPointerDown(PointerEventData eventData)
	{
		if (objekt != null) 
		{
			iconParent = this.transform.parent;
			this.transform.SetParent (this.transform.parent.parent); //beim drag wird die icon als kind element von eltern von eltern element gesetzt, damit es nicht hinter andere objekte bleibt
			this.transform.position = eventData.position;
		}
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (objekt != null) 
		{
			this.transform.position = eventData.position;
		}
	}

	public void OnEndDrag(PointerEventData eventData)	// nach drag zurück zum ursprungliche parent
	{
		this.transform.SetParent (iconParent);
	}
}
