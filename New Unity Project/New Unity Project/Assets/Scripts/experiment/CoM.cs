using UnityEngine;
using System.Collections;

public class CoM : MonoBehaviour {

	public Rigidbody2D rb;
	public PolygonCollider2D pc;
	public Vector2 com;
	public Vector2 p_com; 

	void Awake () 
	{
		rb = gameObject.GetComponent<Rigidbody2D> ();
		com = rb.centerOfMass;

		pc = gameObject.AddComponent<PolygonCollider2D> ();
		pc =gameObject.GetComponent<PolygonCollider2D>();
		p_com = rb.centerOfMass;

		Destroy (pc);
		rb.centerOfMass = p_com;
	}
		
	void Update () 
	{
		Debug.Log ("before: " + com);
		Debug.Log ("with pc: " + p_com);
		Debug.Log ("after: " + rb.centerOfMass);
	
	}
}
