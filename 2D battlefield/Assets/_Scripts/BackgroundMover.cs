using UnityEngine;
using System.Collections;

public class BackgroundMover : MonoBehaviour {

	public float speed;
	public float xMin,xMax;

	private Vector2 currentPosition;

	// Use this for initialization
	void Start () {
		this.Reset ();	//reset spawn position
	}
	
	// Update is called once per frame
	void Update () {
		currentPosition = gameObject.GetComponent<Transform> ().position;
		currentPosition.x -= speed;
		gameObject.GetComponent<Transform> ().position = currentPosition;

		if (currentPosition.x <= xMin)	//once currentPosition reached the 'end' of the map 
		{
			this.Reset();
		}
	}

	void Reset()	//Resets ground to start
	{
		Vector2 resetPosition = new Vector2 (xMax, -3f);
		gameObject.GetComponent<Transform> ().position = resetPosition;
	}
}
