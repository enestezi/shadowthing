using UnityEngine;
using System.Collections;

public class TastaturController : MonoBehaviour {

	private GameObject interaktiv2;
	private Rigidbody2D rb_interaktiv2;

	public float speed = 20;             


	// Use this for initialization
	void Start()
	{
		interaktiv2 = GameObject.FindWithTag ("interakiv2");
		rb_interaktiv2 = interaktiv2.GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		
		float moveHorizontal = Input.GetAxis ("Horizontal");


		float moveVertical = Input.GetAxis ("Vertical");


		Vector2 movement = new Vector2 (moveHorizontal * speed, moveVertical * speed);


		rb_interaktiv2.velocity = movement;
	}
}