using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject hazard;
	public Vector2 spawnValues;
	public int hazardCount;
	public int coinCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public GUIText scoreText;
	public GUIText LivesText;
	private int score;
	private int lives;

	// Use this for initialization
	void Start () {
		GetComponent<AudioSource> ().Play ();
		score = 0;
		lives = 3;
		UpdateScore ();
		UpdateLives ();
		if (lives == 0) {
			Application.LoadLevel("GameOver");
		}
		StartCoroutine (SpawnWaves ());

	}
	
	// Update is called once per frame
	void Update () {
		if (lives == 0) {
			Application.LoadLevel("GameOver");
		}
	
	}
	IEnumerator SpawnWaves() {
		yield return new WaitForSeconds(startWait);
		while(true){
			for (int i=0; i<hazardCount; i++) {
				Vector2 spawnPosition = new Vector2 (spawnValues.x ,Random.Range(-spawnValues.y, spawnValues.y));
				Instantiate (hazard,spawnPosition,Quaternion.identity);
				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds(waveWait);
			hazardCount += 1;
		}
	}

	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}

	public void gotHit(int newLives)
	{
		lives -= newLives;
		UpdateLives ();
	}

	void UpdateLives()
	{
		LivesText.text = "Lives: " + lives;
	}
}