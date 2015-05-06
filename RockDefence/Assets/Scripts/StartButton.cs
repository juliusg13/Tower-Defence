﻿using UnityEngine;
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
			StartCoroutine (Level2());

		}
	}

	IEnumerator WaitBetweenLevel()
	{
		yield return new WaitForSeconds (TimeBetweenLevel);

	}

	IEnumerator Level1()
	{	float z = -1f;
		for (int i = 0; i < 10; i++) {
			Instantiate (groupie, new Vector3 (x_coord_start, y_coord_start, z), transform.rotation);
			yield return new WaitForSeconds (0.5f);
		}
		StartCoroutine (WaitBetweenLevel());
		level2 = true;
	}

	IEnumerator Level2()
	{
		float z = -1f;

		for (int i = 0; i < 8; i++) {
			Instantiate (groupie, new Vector3 (x_coord_start, y_coord_start, z), transform.rotation);
			yield return new WaitForSeconds (0.5f);
		}
		yield return new WaitForSeconds (2f);
		for (int i = 0; i < 5; i++) {
			Instantiate (YoungGroupie, new Vector3 (x_coord_start, y_coord_start, z), transform.rotation);
			yield return new WaitForSeconds (0.5f);
		}
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


//for (int i = 0; i < Groupie_count; i++) {
//	Instantiate (groupie, new Vector3 (x_coord_start, y_coord_start, z), transform.rotation);
//	Instantiate (YoungGroupie, new Vector3 (x_coord_start, y_coord_start, z), transform.rotation);
//	Instantiate (OldGroupie, new Vector3 (x_coord_start, y_coord_start, z), transform.rotation);
//	y_coord_start += length_between_groupies;
//} 
//public void AddEnemiesToList()
//{
//	GameObject[] ItemsInList = GameObject.FindGameObjectsWithTag("Destroy");
//	foreach(GameObject _Enemy in ItemsInList)
//	{
//		AddTarget(_Enemy.transform);
//	}
//}



