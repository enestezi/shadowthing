using UnityEngine;
using System.Collections;

public class Puppe : MonoBehaviour 
{
	public GameObject zerbrechlich;

	// Use this for initialization
	void Awake () 
	{
		zerbrechlich = FindeZerbrechlich (this.gameObject);
	}
	
	private GameObject FindeZerbrechlich(GameObject obj)
	{
		GameObject found = null;
		foreach (Transform t in obj.transform) 
		{
			if (t.gameObject.tag == "zerbrechlichJoint") {
				found = t.gameObject;
				break;
			}
			found = FindeZerbrechlich (t.gameObject);
		}
		return found;
	}

	public void AussehenWechseln(string neuesAussehen)
	{
		EventManager.Instance.Event ("AUSSEHEN", "Wechsel", neuesAussehen);
	}
}
