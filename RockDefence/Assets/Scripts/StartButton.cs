using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StartButton : MonoBehaviour {
	


	public Sprite[] NumberOfLvl;
	public Sprite RockHighlight;
	public Sprite Rockon;
	//public float TimeBetweenLevel = 5;
	//public GameObject Nolvl;
	
	Controller c;
	NumberLvl levelDisplay;

	// Use this for initialization
	void Start () {
		GameObject cont = GameObject.Find ("Controller");
		c = cont.GetComponent<Controller> ();

		GameObject content = GameObject.Find ("NumberLvl");
	 	levelDisplay = content.GetComponent<NumberLvl> ();
	
	}

	// Update is called once per frame
	void Update () {
	}
	
	void OnMouseDown() {

		if (c.GameOn == false) {
			c.GameOn = true;
			Controller.Level currentLevel = c.LevelSequence [c.level];


			StartCoroutine (c.RunLevel (currentLevel));
			Sprite levelPicture = levelDisplay.levelPicture[c.level];
			//picture.levelPicture[] = picture.levelPicture[c.level];

			levelDisplay.GetComponent<SpriteRenderer> ().sprite = levelPicture;
		}

	}

	void OnMouseEnter() {
		
		GetComponent<SpriteRenderer>().sprite = RockHighlight;
	}
	
	void OnMouseExit() {
		
		GetComponent<SpriteRenderer> ().sprite = Rockon;
	}
}






