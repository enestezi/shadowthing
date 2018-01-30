using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScrollRectSnap_CS : MonoBehaviour {

	public RectTransform panel; //to hold the scrollpanel
	public Button[] bttn;
	public RectTransform center; //zentrum to vergleich zwischen butttons array

	private float[] distance; //alle buttuns dinstance to zentrum array

	private float[] distReposition;

	private bool dragging = false; //true beim dragging
	private int bttnDistance; // distance zwischen buttons
	private int minButtonNum; // buttonzahl mit niedrigest distance to zentrum
	private int bttnLenght;

	void Start()
	{
		bttnLenght = bttn.Length;
		distance = new float[bttnLenght];

		distReposition = new float[bttnLenght];

		//button distance
		bttnDistance = (int)Mathf.Abs(bttn[1].GetComponent<RectTransform>().anchoredPosition.x - bttn[0].GetComponent<RectTransform>().anchoredPosition.x); //buttonone= 300 - butten2=0 == 300 buttondist
		print (bttnDistance);


	}

	void Update() 
	{
		for (int i = 0; i < bttn.Length; i++) 
		{
			distReposition[i] = center.GetComponent<RectTransform> ().position.x - bttn [i].GetComponent<RectTransform> ().position.x;

			distance [i] = Mathf.Abs (distReposition[i]); //distance relativ zum zentrum von jedes button

			if (distReposition [i] > 600) //hardcode
			{
				float curX = bttn [i].GetComponent<RectTransform> ().anchoredPosition.x;
				float curY = bttn [i].GetComponent<RectTransform> ().anchoredPosition.y;

				Vector2 newAnchoredPos = new Vector2 (curX + (bttnLenght * bttnDistance), curY); //8 x 300 !
				bttn[i].GetComponent<RectTransform>().anchoredPosition = newAnchoredPos;
			}

			if (distReposition [i] < -600) //hardcode
			{
				float curX = bttn [i].GetComponent<RectTransform> ().anchoredPosition.x;
				float curY = bttn [i].GetComponent<RectTransform> ().anchoredPosition.y;

				Vector2 newAnchoredPos = new Vector2 (curX - (bttnLenght * bttnDistance), curY); //8 x 300 !
				bttn[i].GetComponent<RectTransform>().anchoredPosition = newAnchoredPos;


			}
		}

		float minDistance = Mathf.Min (distance); //get min distance vergl zentrum

		for (int a = 0; a < bttn.Length; a++) 
		{
			if (minDistance == distance [a]) //welche buttons haben min
			{
				minButtonNum = a; //numb von bttn der miite ist
			}
		}

		if (!dragging) 
		{
			// LerpToBttn (minButtonNum * -bttnDistance); damit unendliche schleife funktioniert nicht!
			LerpToBttn (-bttn[minButtonNum].GetComponent<RectTransform>().anchoredPosition.x); //damit die distance zwischen den buttons müssen nicht gleich sein

		}
	
	}

	void LerpToBttn (float position)
	{
		float newX = Mathf.Lerp (panel.anchoredPosition.x, position, Time.deltaTime * 8f);
		Vector2 newPosition = new Vector2 (newX, panel.anchoredPosition.y);

		panel.anchoredPosition = newPosition;
	}

	public void StartDrag()
	{
		dragging = true;
	}

	public void EndDrag()
	{
		dragging = false;
	}
}
