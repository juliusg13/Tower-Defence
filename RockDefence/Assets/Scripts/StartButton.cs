using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {

	public GameObject groupie;
	public GameObject YoungGroupie;
	public GameObject OldGroupie;
	//public int GroupieCount;
	//public float length_between_groupies;
	
	public float x_coord_start;
	public float y_coord_start;
	bool gameOn = false;
	bool level2 = false;
	bool level3 = false; 
	bool level4 = false;
	public Sprite RockHighlight;
	public Sprite Rockon;
	public float TimeBetweenLevel = 5;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnMouseDown() {

		if (gameOn == false) {
			gameOn = true;

			StartCoroutine (Level1());
		}
		else if (level2 == true) {
			level2 = false;
			StartCoroutine (Level2());
		}
		else if (level3 == true)
		{	level3 = false;
			StartCoroutine (Level3());
			
		}
		else if (level4 == true)
		{	level4 = false;
			StartCoroutine (Level4());
			
		}
	}

	IEnumerator WaitBetweenLevel()
	{
		yield return new WaitForSeconds (TimeBetweenLevel);

	}
	IEnumerator Level1()
	{	float z = -1f;
		for (int i = 0; i < 5; i++) {
			Instantiate (groupie, new Vector3 (x_coord_start, y_coord_start, z), transform.rotation);
			yield return new WaitForSeconds (0.9f);
		}
		StartCoroutine (WaitBetweenLevel());
		level2 = true;
	}

	IEnumerator Level2()
	{	float z = -1f;
		for (int i = 0; i < 10; i++) {
			Instantiate (groupie, new Vector3 (x_coord_start, y_coord_start, z), transform.rotation);
			yield return new WaitForSeconds (0.5f);
		}
		StartCoroutine (WaitBetweenLevel());
		level3 = true;
	}

	IEnumerator Level3()
	{
		float z = -1f;

		for (int i = 0; i < 8; i++) {
			Instantiate (groupie, new Vector3 (x_coord_start, y_coord_start, z), transform.rotation);
			yield return new WaitForSeconds (0.5f);
		}
		yield return new WaitForSeconds (1.6f);
		for (int i = 0; i < 5; i++) {
			Instantiate (YoungGroupie, new Vector3 (x_coord_start, y_coord_start, z), transform.rotation);
			yield return new WaitForSeconds (0.5f);
		}
		StartCoroutine (WaitBetweenLevel());
		level4 = true;
	}

	IEnumerator Level4()
	{
		float z = -1f;

		Instantiate (OldGroupie, new Vector3 (x_coord_start, y_coord_start, z), transform.rotation);
		yield return new WaitForSeconds (1f);

		for (int i = 0; i < 4; i++) {
			Instantiate (groupie, new Vector3 (x_coord_start, y_coord_start, z), transform.rotation);
			yield return new WaitForSeconds (0.5f);
		}
		Instantiate (OldGroupie, new Vector3 (x_coord_start, y_coord_start, z), transform.rotation);
		for (int i = 0; i < 4; i++) {
			Instantiate (groupie, new Vector3 (x_coord_start, y_coord_start, z), transform.rotation);
			yield return new WaitForSeconds (0.5f);
		}
		yield return new WaitForSeconds (1.6f);
		for (int i = 0; i < 5; i++) {
			Instantiate (YoungGroupie, new Vector3 (x_coord_start, y_coord_start, z), transform.rotation);
			yield return new WaitForSeconds (0.5f);
		}
		StartCoroutine (WaitBetweenLevel());
	}

	IEnumerator WaitOneSecond()
	{
		yield return new WaitForSeconds (1f);
	}

	IEnumerator WaitTwoSecond()
	{
		yield return new WaitForSeconds (2f);
	}

	void OnMouseEnter() {
		
		GetComponent<SpriteRenderer>().sprite = RockHighlight;
	}
	
	void OnMouseExit() {
		
		GetComponent<SpriteRenderer> ().sprite = Rockon;
	}
}



//public void AddEnemiesToList()
//{
//	GameObject[] ItemsInList = GameObject.FindGameObjectsWithTag("Destroy");
//	foreach(GameObject _Enemy in ItemsInList)
//	{
//		AddTarget(_Enemy.transform);
//	}
//}



