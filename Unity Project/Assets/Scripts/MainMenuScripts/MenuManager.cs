using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //wechsel scene

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

	//public BoxCollider2D decke;
	public GameObject logo;

	void Awake () 
	{
		mainMenu = GameObject.FindGameObjectWithTag ("mainMenu");
		archive = GameObject.FindGameObjectWithTag ("archive");
		logo = GameObject.FindGameObjectWithTag ("logo");

		//decke = GameObject.FindGameObjectWithTag ("boden").GetComponent<BoxCollider2D>();
		istArchiveVersteckt = false;
		istMainMenuVersteckt = true;
	}

	void Start()
	{
		logo.SetActive (false);
	}

	public void Performance ()
	{
		SceneManager.LoadScene (1);
	}
		
	public void Exit()
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit ();
		#endif
	}


	public void MainMenuSlide ()
	{
		archiveList = GetComponent<ArchiveList>();
		
		if (!istMainMenuVersteckt) 
		{
			archiveSlide.SetBool ("versteckt", false);
			mainMenuSlide.SetBool ("versteckt", false);
			//decke.enabled = false;
			logo.SetActive(false);
			istMainMenuVersteckt = true;
			istArchiveVersteckt = false;
			if (archiveList.deaktivierFigur)
				figurSlide.SetBool ("versteckt", true);
		}
		else if (istMainMenuVersteckt) 
		{
			archiveSlide.SetBool ("versteckt", true);
			mainMenuSlide.SetBool ("versteckt", true);
			//decke.enabled = true;
			logo.SetActive(true);
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
