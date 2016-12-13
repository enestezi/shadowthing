using UnityEngine;
using System.Collections;

public class MausradDreh : MonoBehaviour
{
	public float mausradDrehung;        //stores the rotation of the mouse wheel
	public float mausradWert;
	public float mausradGeschwindigkeit = 50.0f;
	public float mausrad;
	public float mausradSmoother = 1.0f;
	private float geschwindigkeit = 10000.0f;      //multiplier for the mouse wheel input

	public bool rigidbodyDreh; // why lil buggy???---


	private Rigidbody2D rb_Lager; //warum muss es so sein :(
	void Start ()
	{
		rigidbodyDreh = false;
//		if (rb_Lager != null) 
//		{
//			rb_Lager.freezeRotation = true;
//		}
	}

	bool wasClicked;

	void Update ()
	{
		if (rb_Lager == null)
			return;
		if (Input.GetMouseButton (1)) 
		{
			if (wasClicked)
				return;
			rigidbodyDreh = !rigidbodyDreh;
			rb_Lager.freezeRotation = rigidbodyDreh;
			wasClicked = true;
		} else 
		{
			wasClicked = false;
		}
	}

	void FixedUpdate ()
	{
		mausrad = Input.GetAxis ("Mouse ScrollWheel");

		if (mausrad != 0.0f) {
			mausradWert =- mausrad * mausradGeschwindigkeit;
			mausradWert = Mathf.Clamp (mausradWert, -100.0F, 100F);
//			if (rb_Lager != null) 
//			{
//				rb_Lager.freezeRotation = false;
//			}
		}

		if (mausrad == 0.0f) {
			mausradWert = 0;
//			if (rb_Lager != null) 
//			{
//				rb_Lager.freezeRotation = true;
//			}
		}

		mausradDrehung = Mathf.Lerp (0.0F, mausradWert, mausradSmoother * Time.deltaTime);


		if (mausradDrehung != 0 && rb_Lager != null)
		{
			//bool tmp = rb_Lager.freezeRotation;
			if(rb_Lager.angularVelocity == 0)
				rb_Lager.freezeRotation = true;
			
			if (mausradDrehung > 0) 
			{
				rb_Lager.AddTorque (mausradDrehung * geschwindigkeit);

			}

			if (mausradDrehung < 0) 
			{
				rb_Lager.AddTorque (mausradDrehung * geschwindigkeit);
			}
			//rb_Lager.freezeRotation = tmp;
		}
	}

	public void Rb_holen (Rigidbody2D rb_geklickt)
	{
		rb_Lager = rb_geklickt;

	}
}