using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StartButton : MonoBehaviour {
	

	public Sprite One;
	public Sprite Two;
	public Sprite Three;
	public Sprite Four;
	public Sprite Five;
	public Sprite Six;
	public Sprite Seven;
	public Sprite Eight;
	public Sprite Nine;
	public Sprite Ten;
	//public float x_coord_start;
	//public float y_coord_start;


	public Sprite[] NumberOfLvl;
	public Sprite RockHighlight;
	public Sprite Rockon;
	//public float TimeBetweenLevel = 5;
	//public GameObject Nolvl;
	
	Controller c;
	// Use this for initialization
	void Start () {
		GameObject cont = GameObject.Find ("Controller");
		c = cont.GetComponent<Controller> ();
	}

	// Update is called once per frame
	void Update () {
	}
	
	void OnMouseDown() {

		if (c.GameOn == false) {
			c.GameOn = true;

			Controller.Level currentLevel = c.LevelSequence [c.level];
			
			StartCoroutine (c.RunLevel (currentLevel));
		}
		/*
		if (c.GameLost == false) {
			if (GameOn == false) {
				GameOn = true;
				if (Level == 1) {
					StartCoroutine (Level1 ());
				}
			} else if (Level == 2) {
				StartCoroutine (Level2 ());
			} else if (Level == 3) {
				
				StartCoroutine (Level3 ());	
			} else if (Level == 4) {
				
				StartCoroutine (Level4 ());
				
			} else if (Level == 5) {
				
				StartCoroutine (Level5 ());
				
			} else if (Level == 6) {
				
				StartCoroutine (Level6 ());
				
			} else if (Level == 7) {
				
				StartCoroutine (Level7 ());
				
			} else if (Level == 8) {
				StartCoroutine (Level8 ());
				
			} else if (Level == 9) {
				StartCoroutine (Level9 ());
				
			} else if (Level == 10) {
				StartCoroutine (Level10 ());
				
			}

		}
		*/
	}
	/*
	
	IEnumerator WaitBetweenLevel()
	{
		yield return new WaitForSeconds (TimeBetweenLevel);
		
	}
	IEnumerator Level1()
	{	Level++;
		float z = -1f;
		this.GetComponent<AudioSource> ().Play ();
		for (int i = 0; i < 3; i++) {
			Instantiate (groupie, new Vector3 (x_coord_start, y_coord_start, z), transform.rotation);
			yield return new WaitForSeconds (1.4f);
		}
		StartCoroutine (WaitBetweenLevel());
		c.RockDollars += 4;
		
		
		//level2 = true;
	}
	
	IEnumerator Level2()
	{			Level++;
		this.GetComponent<AudioSource> ().Play ();
		Nolvl = GameObject.FindGameObjectWithTag ("NumberOfLevel");
		Nolvl.GetComponent<SpriteRenderer> ().sprite = Two;
		float z = -1f;
		//if (this.gameObject.tag == "NumberOfLvl") {
		//	GetComponent<SpriteRenderer> ().sprite = Two;
		//}
		
		for (int i = 0; i < 5; i++) {
			Instantiate (groupie, new Vector3 (x_coord_start, y_coord_start, z), transform.rotation);
			yield return new WaitForSeconds (0.8f);
		}
		c.RockDollars += 4;
		StartCoroutine (WaitBetweenLevel());
		
		
		//level3 = true;
	}
	
	IEnumerator Level3()
	{	Level++;
		float z = -1f;
		this.GetComponent<AudioSource> ().Play ();
		Nolvl = GameObject.FindGameObjectWithTag ("NumberOfLevel");
		Nolvl.GetComponent<SpriteRenderer> ().sprite = Three;
		for (int i = 0; i < 8; i++) {
			Instantiate (groupie, new Vector3 (x_coord_start, y_coord_start, z), transform.rotation);
			yield return new WaitForSeconds (0.6f);
		}
		c.RockDollars += 4;
		StartCoroutine (WaitBetweenLevel());
		
		
		//level4 = true;
	}
	
	IEnumerator Level4()
	{	Level++;
		float z = -1f;
		this.GetComponent<AudioSource> ().Play ();
		Nolvl = GameObject.FindGameObjectWithTag ("NumberOfLevel");
		Nolvl.GetComponent<SpriteRenderer> ().sprite = Four;
		for (int i = 0; i < 8; i++) {
			Instantiate (groupie, new Vector3 (x_coord_start, y_coord_start, z), transform.rotation);
			yield return new WaitForSeconds (0.5f);
		}
		yield return new WaitForSeconds (1.6f);
		for (int i = 0; i < 3; i++) {
			Instantiate (YoungGroupie, new Vector3 (x_coord_start, y_coord_start, z), transform.rotation);
			yield return new WaitForSeconds (0.6f);
		}
		c.RockDollars += 4;
		StartCoroutine (WaitBetweenLevel());
		
		
		//level5 = true;
	}
	
	IEnumerator Level5()
	{	Level++;
		float z = -1f;
		this.GetComponent<AudioSource> ().Play ();
		Nolvl = GameObject.FindGameObjectWithTag ("NumberOfLevel");
		Nolvl.GetComponent<SpriteRenderer> ().sprite = Five;
		for (int i = 0; i < 8; i++) {
			Instantiate (groupie, new Vector3 (x_coord_start, y_coord_start, z), transform.rotation);
			yield return new WaitForSeconds (0.5f);
		}
		yield return new WaitForSeconds (1.6f);
		for (int i = 0; i < 7; i++) {
			Instantiate (YoungGroupie, new Vector3 (x_coord_start, y_coord_start, z), transform.rotation);
			yield return new WaitForSeconds (0.5f);
		}
		c.RockDollars += 4;
		StartCoroutine (WaitBetweenLevel());
		
		
		//level6 = true;
	}
	
	IEnumerator Level6()
	{	Level++;
		float z = -1f;
		this.GetComponent<AudioSource> ().Play ();
		Nolvl = GameObject.FindGameObjectWithTag ("NumberOfLevel");
		Nolvl.GetComponent<SpriteRenderer> ().sprite = Six;
		Instantiate (OldGroupie, new Vector3 (x_coord_start, y_coord_start, z), transform.rotation);
		yield return new WaitForSeconds (2f);
		Instantiate (OldGroupie, new Vector3 (x_coord_start, y_coord_start, z), transform.rotation);
		for (int i = 0; i < 4; i++) {
			Instantiate (groupie, new Vector3 (x_coord_start, y_coord_start, z), transform.rotation);
			yield return new WaitForSeconds (0.5f);
		}
		Instantiate (OldGroupie, new Vector3 (x_coord_start, y_coord_start, z), transform.rotation);
		for (int i = 0; i < 4; i++) {
			Instantiate (groupie, new Vector3 (x_coord_start, y_coord_start, z), transform.rotation);
			yield return new WaitForSeconds (0.5f);
		}
		yield return new WaitForSeconds (1f);
		for (int i = 0; i < 5; i++) {
			Instantiate (YoungGroupie, new Vector3 (x_coord_start, y_coord_start, z), transform.rotation);
			yield return new WaitForSeconds (0.5f);
		}
		//c.RockDollars += 4;
		StartCoroutine (WaitBetweenLevel());
		
		//level7 = true;
	}
	
	IEnumerator Level7()
	{	Level++;
		float z = -1f;
		this.GetComponent<AudioSource> ().Play ();
		Nolvl = GameObject.FindGameObjectWithTag ("NumberOfLevel");
		Nolvl.GetComponent<SpriteRenderer> ().sprite = Seven;
		
		for (int i = 0; i < 3; i++) {
			Instantiate (OldGroupie, new Vector3 (x_coord_start, y_coord_start, z), transform.rotation);
			yield return new WaitForSeconds (0.5f);
		}
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
		
		//level8 = true;
	}
	
	IEnumerator Level8()
	{	Level++;
		float z = -1f;
		this.GetComponent<AudioSource> ().Play ();
		Nolvl = GameObject.FindGameObjectWithTag ("NumberOfLevel");
		Nolvl.GetComponent<SpriteRenderer> ().sprite = Eight;
		for (int i = 0; i < 3; i++) {
			Instantiate (OldGroupie, new Vector3 (x_coord_start, y_coord_start, z), transform.rotation);
			yield return new WaitForSeconds (0.5f);
		}
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
		yield return new WaitForSeconds (1f);
		for (int i = 0; i < 4; i++) {
			Instantiate (groupie, new Vector3 (x_coord_start, y_coord_start, z), transform.rotation);
			yield return new WaitForSeconds (0.5f);
		}
		StartCoroutine (WaitBetweenLevel());
		
		//level9 = true;
	}
	
	IEnumerator Level9()
	{	Level++;
		float z = -1f;
		this.GetComponent<AudioSource> ().Play ();
		Nolvl = GameObject.FindGameObjectWithTag ("NumberOfLevel");
		Nolvl.GetComponent<SpriteRenderer> ().sprite = Nine;
		
		for (int i = 0; i < 8; i++) {
			Instantiate (OldGroupie, new Vector3 (x_coord_start, y_coord_start, z), transform.rotation);
			yield return new WaitForSeconds (0.5f);
		}
		yield return new WaitForSeconds (1f);
		
		for (int i = 0; i < 10; i++) {
			Instantiate (groupie, new Vector3 (x_coord_start, y_coord_start, z), transform.rotation);
			yield return new WaitForSeconds (0.3f);
		}
		Instantiate (OldGroupie, new Vector3 (x_coord_start, y_coord_start, z), transform.rotation);
		for (int i = 0; i < 8; i++) {
			Instantiate (YoungGroupie, new Vector3 (x_coord_start, y_coord_start, z), transform.rotation);
			yield return new WaitForSeconds (0.5f);
		}
		yield return new WaitForSeconds (1.6f);
		for (int i = 0; i < 7; i++) {
			Instantiate (groupie, new Vector3 (x_coord_start, y_coord_start, z), transform.rotation);
			yield return new WaitForSeconds (0.5f);
		}
		yield return new WaitForSeconds (1f);
		for (int i = 0; i < 4; i++) {
			Instantiate (YoungGroupie, new Vector3 (x_coord_start, y_coord_start, z), transform.rotation);
			yield return new WaitForSeconds (0.5f);
		}
		StartCoroutine (WaitBetweenLevel());
		
		//level10 = true;
	}
	
	IEnumerator Level10()
	{Level++;
		float z = -1f;
		this.GetComponent<AudioSource> ().Play ();
		Nolvl = GameObject.FindGameObjectWithTag ("NumberOfLevel");
		Nolvl.GetComponent<SpriteRenderer> ().sprite = Ten;
		for (int i = 0; i < 15; i++) {
			Instantiate (OldGroupie, new Vector3 (x_coord_start, y_coord_start, z), transform.rotation);
			yield return new WaitForSeconds (0.5f);
		}
		yield return new WaitForSeconds (1f);
		
		for (int i = 0; i < 29; i++) {
			Instantiate (groupie, new Vector3 (x_coord_start, y_coord_start, z), transform.rotation);
			yield return new WaitForSeconds (0.3f);
		}
		Instantiate (OldGroupie, new Vector3 (x_coord_start, y_coord_start, z), transform.rotation);
		for (int i = 0; i < 10; i++) {
			Instantiate (YoungGroupie, new Vector3 (x_coord_start, y_coord_start, z), transform.rotation);
			yield return new WaitForSeconds (0.5f);
		}
		Instantiate (OldGroupie, new Vector3 (x_coord_start, y_coord_start, z), transform.rotation);
		yield return new WaitForSeconds (1.6f);
		for (int i = 0; i < 16; i++) {
			Instantiate (groupie, new Vector3 (x_coord_start, y_coord_start, z), transform.rotation);
			yield return new WaitForSeconds (0.5f);
		}
		yield return new WaitForSeconds (1f);
		for (int i = 0; i < 60; i++) {
			Instantiate (YoungGroupie, new Vector3 (x_coord_start, y_coord_start, z), transform.rotation);
			yield return new WaitForSeconds (0.5f);
		}
		StartCoroutine (WaitBetweenLevel());
	}
*/
	void OnMouseEnter() {
		
		GetComponent<SpriteRenderer>().sprite = RockHighlight;
	}
	
	void OnMouseExit() {
		
		GetComponent<SpriteRenderer> ().sprite = Rockon;
	}
}






