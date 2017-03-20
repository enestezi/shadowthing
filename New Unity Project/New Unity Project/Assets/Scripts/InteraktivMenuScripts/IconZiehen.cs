using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

//Objektdaten on icon
public class IconZiehen : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
	public LidoObjekt objekt;	//siehe interaktivList
	public int halterNr;	//siehe interaktivList //welche halter ist das objekt in
	public string signaturIcon;
	public GameObject figur;

	private InteraktivList intList;
	private IconDaten iconDaten;

	private Vector2 iconPos;
	private Image iconSprite;
	private Color iconSpriteColor; 

	private Vector2 posUmgerechnet;

	public PointerEventData data;

	public CanvasGroup canvasGr;

	void Start () 
	{
		intList = GameObject.FindGameObjectWithTag ("menuManager").GetComponent<InteraktivList> ();
		iconDaten = intList.GetComponent<IconDaten> ();
		iconSprite = this.GetComponent<Image> ();
		iconSpriteColor = iconSprite.color;
		signaturIcon = objekt.Signatur;
		canvasGr = GetComponent<CanvasGroup> ();
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		data = eventData;
		this.transform.position = eventData.position;
	}

	public void OnBeginDrag (PointerEventData eventData)
	{
		if (objekt != null) 
		{
			iconSpriteColor.a = 1;
			iconSprite.color = iconSpriteColor;

			iconDaten.DeaktiviereDaten ();
			this.transform.SetParent (this.transform.parent.parent); //beim drag wird die icon als kind element von eltern von eltern element gesetzt, damit es nicht hinter andere objekte bleibt
			this.transform.position = eventData.position;
			canvasGr.blocksRaycasts = false;
			iconSpriteColor.a = 1;
			iconSprite.color = iconSpriteColor;
		}
	}

	public void OnDrag(PointerEventData eventData)
	{
		
		if (objekt != null) 
		{
			iconPos = this.transform.position;
			this.transform.position = eventData.position;

			// aktiviere Figur usw.
			if (iconPos.y >= 300) 
			{
				intList.AktiviereFigur (objekt.Signatur);
				this.transform.position = eventData.position;
				posUmgerechnet = Camera.main.ScreenToWorldPoint(eventData.position);
				figur = intList.HolePoolFigur (objekt.Signatur);
				figur.GetComponentInChildren<TargetJoint2D>().target = posUmgerechnet;	//TODO: Performance?

				iconSpriteColor.a = 0;
				iconSprite.color = iconSpriteColor;
			} 
			else if (iconPos.y <= 300)
			{
				this.transform.position = eventData.position;
				intList.DeaktiviereFigur (objekt.Signatur);
				iconSpriteColor.a = 1;
				iconSprite.color = iconSpriteColor;
			}

		}
	}

	public void OnEndDrag(PointerEventData eventData)	
	{
		this.transform.SetParent (intList.halterList [halterNr].transform);	// nach drag zurück zum ursprungliche parent
		this.transform.position = intList.halterList [halterNr].transform.position;
		canvasGr.blocksRaycasts = true;
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
		
}
