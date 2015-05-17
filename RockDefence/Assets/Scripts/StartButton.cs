using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StartButton : MonoBehaviour {
	

	
	public AudioClip[] clips;
	public Sprite[] NumberOfLvl;
	public Sprite RockHighlight;
	public Sprite Rockon;
	Controller c;
	NumberLvl levelDisplay;
	AudioSource source;

	// Use this for initialization
	void Start () {
		GameObject cont = GameObject.Find ("Controller");
		c = cont.GetComponent<Controller> ();

		GameObject content = GameObject.Find ("NumberLvl");
	 	levelDisplay = content.GetComponent<NumberLvl> ();

		source = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
	}
	
	void OnMouseDown() {
	if (c.GameLost == false) {
			if (c.GameOn == false) {
				RandomPlayClip ();
				c.GameOn = true;
				Controller.Level currentLevel = c.LevelSequence [c.level];

				StartCoroutine (c.RunLevel (currentLevel));
				Sprite levelPicture = levelDisplay.levelPicture [c.level];
				//picture.levelPicture[] = picture.levelPicture[c.level];

				levelDisplay.GetComponent<SpriteRenderer> ().sprite = levelPicture;
			}
		}
	}

	void OnMouseEnter() {
		
		GetComponent<SpriteRenderer>().sprite = RockHighlight;
	}
	
	void OnMouseExit() {
		
		GetComponent<SpriteRenderer> ().sprite = Rockon;
	}

	public void RandomPlayClip()
	{
		source.clip = clips[Random.Range(0,clips.Length)];
		source.Play ();


	}

}

 


