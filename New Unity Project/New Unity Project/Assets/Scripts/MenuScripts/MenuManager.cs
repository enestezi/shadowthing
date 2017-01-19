using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

	public GameObject mainMenu;
	public GameObject archive;

	public ArchiveList archiveList;

	void Awake () 
	{
		mainMenu = GameObject.FindGameObjectWithTag ("mainMenu");
		archive = GameObject.FindGameObjectWithTag ("archive");
		archive.SetActive (false);
	}

	public void Archive ()
	{
		mainMenu.SetActive(false);
		archive.SetActive (true);
	}

	public void Exit()
	{
		Application.Quit();
	}

	public void zurueckMainMenu ()
	{
		archiveList = GameObject.FindGameObjectWithTag ("inhaltPanel").GetComponent<ArchiveList>();

		archive.SetActive (false);
		archiveList.deaktivierFigur.SetActive (false);
		mainMenu.SetActive(true);
	}

}
