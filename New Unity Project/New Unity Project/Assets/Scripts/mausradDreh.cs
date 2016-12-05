using UnityEngine;
using System.Collections;

public class MausradDreh : MonoBehaviour
{
	public float mausradDrehung;        //stores the rotation of the mouse wheel
	public float mausradWert;
	public float mausradGeschwindigkeit = 50.0f;
	public float mausrad;
	public float mausradSmoother = 2.0f;
	private float geschwindigkeit = 10000.0f;      //multiplier for the mouse wheel input
	private Vector3 objPos;

	private GameObject interaktiv1Dreh;
	private Rigidbody2D interaktiv1Rigid;

	void Start ()
	{
		interaktiv1Dreh = GameObject.FindWithTag ("interakiv1");
		interaktiv1Rigid = interaktiv1Dreh.GetComponent<Rigidbody2D> ();
	}
	void FixedUpdate ()
	{
		mausrad = Input.GetAxis ("Mouse ScrollWheel");
		if (mausrad != 0.0f) {
			mausradWert -= mausrad * mausradGeschwindigkeit;
			mausradWert = Mathf.Clamp (mausradWert, -50.0F, 50F);
		}

		if (mausrad == 0.0f) {
			mausradWert = 0;
		}

		mausradDrehung = Mathf.Lerp (0.0F, mausradWert, mausradSmoother * Time.deltaTime);

		if (mausradDrehung != 0)
		{
			interaktiv1Rigid.freezeRotation = false;

			if (mausradDrehung > 0) {
				interaktiv1Rigid.AddTorque(mausradDrehung * geschwindigkeit);
			}
			if (mausradDrehung < 0) {
				interaktiv1Rigid.AddTorque(mausradDrehung * geschwindigkeit);
			}
		}

	}
}