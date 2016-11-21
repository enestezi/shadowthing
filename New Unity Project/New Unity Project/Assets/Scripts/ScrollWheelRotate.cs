using UnityEngine;
using System.Collections;

public class ScrollWheelRotate : MonoBehaviour {

	private GameObject interaktiv1Dreh;   
	public Vector3 drehAchse;			// e.g. set this to 0 0 1 for Z
	public float geschwindigkeit = 10000.0f;      		//multiplier for the mouse wheel input

	private float mausradDrehwert;        			//stores the mausradDrehwert of the mouse wheel
	private Vector3 objPos; 			//stores the mausradDrehwert of the attached gameObject

	private Ray2D ray;
	private RaycastHit2D hit;

	void Start () 
	{
		interaktiv1Dreh = GameObject.FindWithTag ("interakiv1");
	}


	void Update () 
	{

			objPos = interaktiv1Dreh.transform.eulerAngles; 
			mausradDrehwert = Input.GetAxis("Mouse ScrollWheel") * geschwindigkeit * Time.deltaTime; 

			// Check if the mouse is over some collider 

			// the hit collider test is to lock the mausradDrehwert around a desired object

			if (mausradDrehwert != 0 ) 
		
			{ 
				
				Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				hit = Physics2D.Raycast(ray, -Vector2.zero);

			if (hit.collider != null) {
				if (hit.collider.tag == "interakiv1") {
					interaktiv1Dreh = hit.collider.gameObject;
					objPos = interaktiv1Dreh.transform.eulerAngles;  // keeps objPos up to date 
					objPos = new Vector3 (
						Mathf.LerpAngle (objPos.x, objPos.x, Time.deltaTime), 
						Mathf.LerpAngle (objPos.y, objPos.y, Time.deltaTime),
						Mathf.LerpAngle (objPos.z, objPos.z+(mausradDrehwert * drehAchse.z), Time.deltaTime));
					interaktiv1Dreh.transform.eulerAngles = objPos;
				}
			}
				
			}

				if (interaktiv1Dreh != null) { // null check
					interaktiv1Dreh.transform.eulerAngles = objPos;
				}

		
			}


		
	
		}
		
