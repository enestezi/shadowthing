using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

	public GameObject mainMenu;
	public Animator mainMenuSlide;
	public bool istMainMenuVersteckt;

	public GameObject archive;
	public Animator archiveSlide;
	public bool istArchiveVersteckt;

	public ArchiveList archiveList;
	public Animator figurSlide;
	public bool istFigurVersteckt;

	void Awake () 
	{
		mainMenu = GameObject.FindGameObjectWithTag ("mainMenu");
		archive = GameObject.FindGameObjectWithTag ("archive");
		istArchiveVersteckt = true;
		istMainMenuVersteckt = false;
	}
		

	public void Exit()
	{
		Application.Quit();
	}


	public void MainMenuSlide ()
	{
		archiveList = GameObject.FindGameObjectWithTag ("inhaltPanel").GetComponent<ArchiveList>();
		
		if (!istMainMenuVersteckt) 
		{
			archiveSlide.SetBool ("versteckt", false);
			mainMenuSlide.SetBool ("versteckt", false);
			istMainMenuVersteckt = true;
			istArchiveVersteckt = false;
			if (archiveList.deaktivierFigur)
				figurSlide.SetBool ("versteckt", true);
		}
		else if (istMainMenuVersteckt) 
		{
			archiveSlide.SetBool ("versteckt", true);
			mainMenuSlide.SetBool ("versteckt", true);
			istMainMenuVersteckt = false;
			istArchiveVersteckt = true;
			if (archiveList.deaktivierFigur)
				figurSlide.SetBool ("versteckt", false);
		}
	}

	public void SlideInOut ()
	{
		if (!istArchiveVersteckt) 
		{
			archiveSlide.SetBool ("versteckt", true);
			istArchiveVersteckt = true;
		}
		else if (istArchiveVersteckt) 
		{
			archiveSlide.SetBool ("versteckt", false);
			istArchiveVersteckt = false;
		}
	}


		
}
