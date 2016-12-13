using UnityEngine;
using System.Collections;

public class Interaktiv1Parent : MonoBehaviour 
{
	public GameObject zerbrechlich;
	public GameObject interaktiv2;
	// Use this for initialization
	void Awake () 
	{
		zerbrechlich = FindeObjektmitTag (this.gameObject, "zerbrechlichJoint");
		interaktiv2 = FindeObjektmitTag (this.gameObject, "interakiv2");
	}


	private GameObject FindeObjektmitTag(GameObject obj, string suchTag)
	{
		GameObject found = null;
		foreach (Transform t in obj.transform) 
		{
			if (t.gameObject.tag == suchTag) {
				return t.gameObject;
			}
			found = FindeObjektmitTag (t.gameObject, suchTag);
			if (found != null) //der findet aber sucht weiter, und überschreibt vorherige ergebnis mit null, deswegen so weit es gefunden wird, muss break!
				break;
		}
		return found;
	}

	// ausziehen wechsel muss umgezogen werden

	public void AussehenWechseln(string neuesAussehen)
	{
		EventManager.Instance.Event ("AUSSEHEN", "Wechsel", neuesAussehen);
	}
}
