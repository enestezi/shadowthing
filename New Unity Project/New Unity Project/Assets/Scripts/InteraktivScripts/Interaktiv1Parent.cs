using UnityEngine;
using System.Collections;


//Script zum Finden der Kinderelemente, die für FixedJoint relevant sind
public class Interaktiv1Parent : MonoBehaviour 
{
	public GameObject zerbrechlich;
	public GameObject interaktiv2;

	void Awake () 
	{
		// ruf die Funktion, gib tag's als String und dieses Script erhaltene gameObject's mit
		zerbrechlich = FindeObjektmitTag (this.gameObject, "zerbrechlichJoint");
		interaktiv2 = FindeObjektmitTag (this.gameObject, "interakiv2");
	}

	// Funktion zum Finden der Objekte mit gegebenen tags
	private GameObject FindeObjektmitTag(GameObject obj, string suchTag)
	{
		GameObject found = null;

		foreach (Transform t in obj.transform) //jede GameObject hat in Transform component, deswegen wird objekte mit Transform in Kinderelemente durch gegangen
		{
			if (t.gameObject.tag == suchTag) 
			{
				return t.gameObject;
			}
			found = FindeObjektmitTag (t.gameObject, suchTag);
			if (found != null) //der findet aber sucht weiter, und überschreibt vorherige ergebnis mit null, deswegen so weit es gefunden wird, muss break!
				break;
		}
		return found;
	}


	// TODO ausziehen wechsel muss umgezogen werden

	public void AussehenWechseln(string neuesAussehen)
	{
		EventManager.Instance.Event ("AUSSEHEN", "Wechsel", neuesAussehen);
	}
}
