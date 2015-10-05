using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, yMin, yMax;
}
public class WizardController : MonoBehaviour {

	public float speed;
	Animator anim;
	public float fireRate;
	public GameObject shot;
	public Transform shotSpawn;

	public Boundary boundary;

	private float nextFire;

	void Start()
	{
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		while (Input.GetButton ("Fire1") && Time.time > nextFire) 
		{
			anim.SetBool ("Mouse", true);
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			GetComponent<AudioSource>().Play();
		}

		//if (Input.GetButtonDown ("Fire1") && Time.time > nextFire) {
		//	anim.SetBool ("Mouse", true);
		//	nextFire = Time.time + fireRate;
		//	Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		//	GetComponent<AudioSource>().Play();
		//}
		if (Input.GetButtonUp ("Fire1")) {
			anim.SetBool("Mouse", false);
		}

	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		GetComponent<Rigidbody2D> ().velocity = movement * speed;
		
			GetComponent<Rigidbody2D> ().position = new Vector2 (
				
				Mathf.Clamp (GetComponent<Rigidbody2D> ().position.x, boundary.xMin, boundary.xMax),
				Mathf.Clamp (GetComponent<Rigidbody2D> ().position.y, boundary.yMin, boundary.yMax)
		);
			}
		
	}
