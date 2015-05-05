using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {

	public GameObject groupie;
	public GameObject YoungGroupie;
	public GameObject OldGroupie;
	public int Groupie_count;
	public float length_between_groupies;
	
	public float x_coord_start;
	public float y_coord_start;
	bool gameOn = false;
	public Sprite RockHighlight;
	public Sprite Rockon;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnMouseDown() {
		if (gameOn == false) {
			gameOn = true;
			float z = -1f;
			for (int i = 0; i < Groupie_count; i++) {
				Instantiate (groupie, new Vector3 (x_coord_start, y_coord_start, z), transform.rotation);
				Instantiate (YoungGroupie, new Vector3 (x_coord_start, y_coord_start, z), transform.rotation);
				Instantiate (OldGroupie, new Vector3 (x_coord_start, y_coord_start, z), transform.rotation);
				y_coord_start += length_between_groupies;
			} 
		}
	//	if (built == false) {
	//		float x = this.transform.position.x;
	//		float y = this.transform.position.y;
	//		Instantiate (speaker, new Vector3 (x, y, 1), transform.rotation);
	//		built = true;
	//	}
	}
	void OnMouseEnter() {
		
		GetComponent<SpriteRenderer>().sprite = RockHighlight;
	}
	
	void OnMouseExit() {
		
		GetComponent<SpriteRenderer> ().sprite = Rockon;
	}
}

