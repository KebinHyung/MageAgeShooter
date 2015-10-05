using UnityEngine;
using System.Collections;

public class GameOverController : MonoBehaviour {

	public GUIText restartText;
	private float activateTime; 

	void Start()
	{
		activateTime = Time.time + 2.0f;
	}

	void OnLevelWasLoaded()
	{
		GetComponent<AudioSource> ().Play ();

		restartText.text = "Press 'R' to restart";


	}

	void Update()
	{
		if (Time.time > activateTime) 
		{
			restartText.enabled = true;
		}

		if (Input.GetKeyDown(KeyCode.R))
		{
			Application.LoadLevel("Main");
		}
	}

}
