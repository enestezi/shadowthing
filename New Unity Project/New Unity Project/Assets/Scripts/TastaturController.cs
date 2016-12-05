using UnityEngine;
using System.Collections;

public class TastaturController : MonoBehaviour {

	private GameObject interaktiv2;
	private Rigidbody2D rb_interaktiv2;

	public float speed = 20;             //Floating point variable to store the player's movement speed.


	// Use this for initialization
	void Start()
	{
		interaktiv2 = GameObject.FindWithTag ("interakiv2");
		rb_interaktiv2 = interaktiv2.GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		//Store the current horizontal input in the float moveHorizontal.
		float moveHorizontal = Input.GetAxis ("Horizontal");

		//Store the current vertical input in the float moveVertical.
		float moveVertical = Input.GetAxis ("Vertical");

		//Use the two store floats to create a new Vector2 variable movement.
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

		//Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
		rb_interaktiv2.AddForce (movement * speed);
	}
}