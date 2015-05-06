﻿using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

	public GameObject orange;
	public GameObject blue;

	public bool built;

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
		float x = this.transform.position.x;
		float y = this.transform.position.y;

		GameObject cont = GameObject.Find ("Controller");
		Controller c = cont.GetComponent<Controller> ();



		if(c.isMenu == false) {

			GameObject OBM = (GameObject)Instantiate(orange, new Vector3(x+0.2f,y-0.75f, -1), transform.rotation);
			GameObject BBM = (GameObject)Instantiate(blue, new Vector3(x+0.9f,y-0.75f,-1), transform.rotation);
			c.isMenu = true;

			OBM.GetComponent<BuildMenu>().SourceTile = this.gameObject;
			BBM.GetComponent<BuildMenu>().SourceTile = this.gameObject;
			//Instantiate (speaker, new Vector3 (x, y, 1), transform.rotation);
			//built = true;
		}
		else {
			GameObject OM = GameObject.Find ("Orange box(Clone)");
			GameObject BM = GameObject.Find ("Blue box(Clone)");
			Destroy(OM);
			Destroy(BM);
			c.isMenu = false;
		}
	}
	void OnMouseEnter() {
		if (this.gameObject.tag == "Buildable") {
			GetComponent<SpriteRenderer> ().sprite = highlight;
		}
	}

	void OnMouseExit() {
		if (this.gameObject.tag == "Buildable") {
			GetComponent<SpriteRenderer> ().sprite = normal;
		}
	}
}