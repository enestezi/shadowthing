using UnityEngine;
using System.Collections;

public class mausradDreh : MonoBehaviour
{
	public float mausradDrehung;        //stores the rotation of the mouse wheel
	private float geschwindigkeit = 1500.0f;      //multiplier for the mouse wheel input
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
		mausradDrehung = Input.GetAxis("Mouse ScrollWheel") * geschwindigkeit * Time.deltaTime;

		if (mausradDrehung != 0)
		{
			interaktiv1Rigid.freezeRotation = false;

			if (mausradDrehung > 0) {
				interaktiv1Rigid.AddTorque(mausradDrehung * geschwindigkeit);
			}
			if (mausradDrehung < 0) {
				interaktiv1Rigid.AddTorque(-(mausradDrehung * geschwindigkeit));
			}
		}
	}
}