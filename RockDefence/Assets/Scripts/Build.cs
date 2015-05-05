﻿using UnityEngine;
using System.Collections;

public class Build : MonoBehaviour {
	public GameObject speaker;
	bool built;
	public Sprite highlight;
	public Sprite normal;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
	/*void OnMouseUp () {

	}*/

	void OnMouseDown() {
		if (built == false) {
			float x = this.transform.position.x;
			float y = this.transform.position.y;
			Instantiate (speaker, new Vector3 (x, y, 1), transform.rotation);
			built = true;
		}
	}
	void OnMouseEnter() {

		GetComponent<SpriteRenderer>().sprite = highlight;
	}

	void OnMouseExit() {

		GetComponent<SpriteRenderer> ().sprite = normal;
	}
}
