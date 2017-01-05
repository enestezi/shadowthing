using UnityEngine;
using System.Collections;


// Script für Rigidbody2D-Rotation durch Scroll und Freigabe des Dreh durch Rechtsklick
public class MausradDreh : MonoBehaviour
{
	public float mausradDrehung;       				//stores the rotation of the mouse wheel
	public float mausradWert;						//das Wert, das später Drehfunktion weitergegeben wird
	public float mausradGeschwindigkeit = 50f;		//Erhöht das scroll-input
	public float mausrad;							// scroll-input
	public float mausradSmoother = 1f;				// erhöhung Wert in Lerp-Funktion in Time.deltaTime
	public float geschwindigkeit = 300.0f;      	// dreh geschwindigkeit 

	private Rigidbody2D rb_Lager; 					// Lager für Rigidbody2D, das von ObjektGeklickt script kommt 

	void FixedUpdate ()
	{
		mausrad = Input.GetAxis ("Mouse ScrollWheel");

		if (mausrad != 0.0f) {
			mausradWert =- mausrad * mausradGeschwindigkeit;
			//mausradWert = Mathf.Lerp (0.0F, mausradWert,mausradSmoother*Time.deltaTime);
			mausradWert = Mathf.Clamp (mausradWert, -100.0F, 100F);


		}

		if (mausrad == 0.0f) {
			mausradWert = 0;
		}

		mausradDrehung = Mathf.Lerp (0.0F, mausradWert, mausradSmoother * Time.deltaTime);

		// rechts klick um drehen/schaukeln zu erlauben
		if (mausradDrehung == 0 && rb_Lager != null) 
		{
			if (Input.GetMouseButton (1)) {
				rb_Lager.freezeRotation = false;
			} else
				rb_Lager.freezeRotation = true;
		}
		else if (rb_Lager != null)
			rb_Lager.freezeRotation = false;
			
		// Drehen mit scroll
		if (mausradDrehung != 0 && rb_Lager != null)
		{
			if (mausradDrehung > 0) 
			{
				rb_Lager.AddTorque (mausradDrehung * geschwindigkeit, ForceMode2D.Impulse); 
			}

			if (mausradDrehung < 0) 
			{
				rb_Lager.AddTorque (mausradDrehung * geschwindigkeit, ForceMode2D.Impulse);
			}
		}
	}
	// Funktion zum entsprechendes Rigidbody2D zu holen
	public void Rb_holen (Rigidbody2D rb_geklickt)
	{
		rb_Lager = rb_geklickt;
	}
}