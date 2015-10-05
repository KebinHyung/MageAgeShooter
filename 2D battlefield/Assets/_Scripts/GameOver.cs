using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<AudioSource> ().Play ();
	}

	void OnLevelWasLoaded()
	{
		GetComponent<AudioSource> ().Play ();
	}
}
