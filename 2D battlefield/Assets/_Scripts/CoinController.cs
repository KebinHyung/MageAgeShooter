using UnityEngine;
using System.Collections;

public class CoinController : MonoBehaviour {

	//Public Instance Variables
	public float speed;
	public int scoreValue;
	public GameController gameController;

	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) 
		{
			//gameController = gameControllerObject.GetComponent<GameController>();
		}
		if (gameControllerObject == null) 
		{
			Debug.Log("Cannot find 'GameController' script");
		}
		this._Reset();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 currentPosition = gameObject.GetComponent<Transform> ().position;
		currentPosition.x -= speed;
		gameObject.GetComponent<Transform> ().position = currentPosition;
		
		//Check boundary
		if (currentPosition.x <= -3.3f) 
		{
			this._Reset();
		}
	}
	private void _Reset()
	{
		Vector2 resetPosition = new Vector2 (12f, Random.Range(-3.7f,3.7f));
		gameObject.GetComponent<Transform> ().position = resetPosition;
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.tag == "Boundary" || other.tag == "Enemy") {
			return;
		}
		if (other.tag == "Player") {
			this._Reset ();
			gameController.AddScore(scoreValue);
			GetComponent<AudioSource>().Play();

		}
	}

}
