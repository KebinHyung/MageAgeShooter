using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
	Animator anim;
	//public int scoreValue;
	private GameController gameController;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) 
		{
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		if (gameControllerObject == null) 
		{
			Debug.Log("Cannot find 'GameController' script");
		}
		anim = GetComponent<Animator> ();
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.tag == "Boundary" || other.tag == "Coin")
		{
			return;
		}
		anim.SetBool ("Hit", true);
		GetComponent<AudioSource> ().Play ();
		gameObject.GetComponent<Collider2D> ().enabled = false;
		Destroy (gameObject, 1f);
		//Destroy(other.gameObject);

		if (other.tag == "Player") {
			gameController.gotHit(1);
			//Destroy(other.gameObject);
		}
	}
}
