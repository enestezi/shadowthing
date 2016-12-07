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
	private Vector3 objPos;

	private GameObject[] interaktiv1Dreh;
	private Rigidbody2D[] rb_interaktiv1Dreh;

	public bool rigidbodyDreh; // why lil buggy???---
	void Start ()
	{
		interaktiv1Dreh = GameObject.FindGameObjectsWithTag ("interakiv1"); // must made with findgameobjectswithtag
		rb_interaktiv1Dreh = new Rigidbody2D[interaktiv1Dreh.Length];
		for (int i = 0; i < interaktiv1Dreh.Length; ++i) 
		{
			rb_interaktiv1Dreh [i] = interaktiv1Dreh[i].GetComponent<Rigidbody2D> ();
		}

		rigidbodyDreh = false;
	}
	void FixedUpdate ()
	{
		if (Input.GetMouseButton (1)) 
		{
			if (!rigidbodyDreh) 
			{
				for (int i = 0; i < interaktiv1Dreh.Length; ++i) 
				{
					rb_interaktiv1Dreh[i].freezeRotation = true;
				}
				rigidbodyDreh = true;
			} 
			else 
			{
				for (int i = 0; i < interaktiv1Dreh.Length; ++i) 
				{
					rb_interaktiv1Dreh[i].freezeRotation = false;
				}
				rigidbodyDreh = false;
			}
		}


		mausrad = Input.GetAxis ("Mouse ScrollWheel");
		if (mausrad != 0.0f) {
			mausradWert -= mausrad * mausradGeschwindigkeit;
			mausradWert = Mathf.Clamp (mausradWert, -100.0F, 100F);
		}

		if (mausrad == 0.0f) {
			mausradWert = 0;
		}

		mausradDrehung = Mathf.Lerp (0.0F, mausradWert, mausradSmoother * Time.deltaTime);

		if (mausradDrehung != 0)
		{
			for (int i = 0; i < interaktiv1Dreh.Length; ++i) 
			{
				rb_interaktiv1Dreh[i].freezeRotation = false;
			}

			if (mausradDrehung > 0) 
			{
				for (int i = 0; i < interaktiv1Dreh.Length; ++i) 
				{
					rb_interaktiv1Dreh [i].AddTorque (mausradDrehung * geschwindigkeit);
				}
			}
			if (mausradDrehung < 0) 
			{
				for (int i = 0; i < interaktiv1Dreh.Length; ++i) 
				{
					rb_interaktiv1Dreh [i].AddTorque (mausradDrehung * geschwindigkeit);
				}
			}
		}

	}
}