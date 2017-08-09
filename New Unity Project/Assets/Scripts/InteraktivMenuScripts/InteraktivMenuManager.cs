using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteraktivMenuManager : MonoBehaviour {

	public Animator iconPanelSlide;
	public bool IconPanelVersteckt;

	public Animator hideSlide;
	public bool HideVersteckt;

	public bool menuOn;

	// Use this for initialization
	void Awake () 
	{
		IconPanelVersteckt = false;
		HideVersteckt = false;
		menuOn = true;
	}
	
	public void VersteckeIconPanel()
	{
		if (IconPanelVersteckt && HideVersteckt) 
		{
			iconPanelSlide.SetBool ("versteckt", false);
			hideSlide.SetBool ("verstecktClose", false);
			IconPanelVersteckt = false;
			HideVersteckt = false;
			menuOn = true;
		}
		else if (!IconPanelVersteckt && !HideVersteckt) 
		{
			iconPanelSlide.SetBool ("versteckt", true);
			hideSlide.SetBool ("verstecktClose", true);
			IconPanelVersteckt = true;
			HideVersteckt = true;
			menuOn = false;
		}
	}

	public void Zuruck(){
		SceneManager.LoadScene (0);
	}
}
