using UnityEngine;
using System.Collections;

public class Mute : MonoBehaviour {
	// Use this for initialization
	bool sound = true;
	public Sprite MuteSprite;
	public Sprite UnMuteSprite;

	// Update is called once per frame

	void OnMouseDown() {
		//audio.Pause();
		SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
		if (sound) {
			AudioListener.volume = 0.0f;
			//Instantiate(MuteObj,new Vector3(transform.position.x, transform.position.y, -1),Quaternion.identity);
			sr.sprite = MuteSprite;
			sound = false;
			//audio.mute = false;
		} else {
			AudioListener.volume = 1f;
			sr.sprite = UnMuteSprite;
			sound = true;
		}
			//audio.mute = true;
	}
	void Update() {
		//if (Input.GetKeyDown(KeyCode.Space))
		
		
	}
}
