﻿using UnityEngine;
using System.Collections;

public class BuildMenu : MonoBehaviour {

	public GameObject speaker;
	public GameObject bar;
	public GameObject SourceTile;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown() {
		GameObject cont = GameObject.Find ("Controller");
		Controller c = cont.GetComponent<Controller> ();

		bool isBuilt = SourceTile.GetComponent<Tile> ().built;

		float x = this.transform.position.x;
		float y = this.transform.position.y;

		if (c.isMenu == true) {
			if((this.gameObject.name == "Orange box(Clone)") && isBuilt == false){
				GameObject BM = GameObject.Find ("Blue box(Clone)");
				Instantiate(speaker, new Vector3(x-0.2f, y+0.75f, 1), transform.rotation);
				Destroy(this.gameObject);
				Destroy (BM);
				c.isMenu = false;
				SourceTile.GetComponent<Tile> ().built = true;
				//built = true;
			}
			else if(this.gameObject.name == "Blue box(Clone)" && isBuilt == false){
				GameObject OM = GameObject.Find ("Orange box(Clone)");
				Instantiate (bar, new Vector3(x-0.9f,y+0.75f,1), transform.rotation);
				Destroy(this.gameObject);
				Destroy (OM);
				c.isMenu = false;
				SourceTile.GetComponent<Tile> ().built = true;
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

	}
}