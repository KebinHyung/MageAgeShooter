using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int startingHealth;
	public int healthPerHeart;

	public GUITexture heartGUI;

	private ArrayList hearts = new ArrayList();
	public int maxHearts;
	private float spacingX;
	private float spacingY;


	// Use this for initialization
	void Start () {
		spacingX = heartGUI.pixelInset.width;
		spacingY = heartGUI.pixelInset.height;
		AddHearts (startingHealth / healthPerHeart);
	}

	public void AddHearts(int n)
	{
		for (int i = 0; i<n; i++) {
			Transform newHeart = ((GameObject) Instantiate(heartGUI.gameObject)).transform;
			newHeart.parent = this.transform.parent;

			int y = Mathf.FloorToInt(hearts.Count / maxHearts);
			int x = hearts.Count - y * maxHearts;

			newHeart.GetComponent<GUITexture>().pixelInset = new Rect(	x * spacingX, y * spacingY, 5.8f,5.8f);

			hearts.Add(newHeart);
		}
	}

	public void ModifyHealth(int amount)
	{

	}

}
