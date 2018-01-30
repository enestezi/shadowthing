using UnityEngine;
using System.Collections;


//Script für Tastaturkontroll
public class TastaturController : MonoBehaviour {

	private Rigidbody2D rb_Lager;	 		// Lager für Rigidbody2D, das von ObjektGeklickt script kommt 	
	public float geschwindigkeit = 20;      // Bewegungsgeschwindigkeit    

	private float horizontal;
	private float vertical;
	private Vector2 bewegung;

	void FixedUpdate()
	{
		horizontal = Input.GetAxis ("Horizontal");
		vertical = Input.GetAxis ("Vertical");

		bewegung = new Vector2 (horizontal * geschwindigkeit, vertical * geschwindigkeit);

		if (rb_Lager != null) //wenn rigidbody2d geholt ist
		{
			rb_Lager.velocity = bewegung;	//bewege
		}
	}

	// Funktion zum entsprechendes Rigidbody2D zu holen
	public void Rb_holen (Rigidbody2D rb_geklickt)
	{
		rb_Lager = rb_geklickt;

	}
}