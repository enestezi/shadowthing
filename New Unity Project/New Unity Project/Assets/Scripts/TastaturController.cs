using UnityEngine;
using System.Collections;

public class TastaturController : MonoBehaviour {

	private GameObject interaktiv2;
	private Rigidbody2D rb_interaktiv2;

	private Rigidbody2D rb_Lager;
	public float speed = 20;             


	// Use this for initialization
	void Start()
	{

	}

	void Update()
	{
		
		float moveHorizontal = Input.GetAxis ("Horizontal");


		float moveVertical = Input.GetAxis ("Vertical");

		Vector2 movement = new Vector2 (moveHorizontal * speed, moveVertical * speed);

		if (rb_Lager != null) {
			rb_Lager.velocity = movement;
		}
	}

	public void Rb_holen (Rigidbody2D rb_geklickt)
	{
		rb_Lager = rb_geklickt;

	}
}