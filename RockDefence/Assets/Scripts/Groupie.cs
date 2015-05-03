using UnityEngine;
using System.Collections;

public class Groupie : MonoBehaviour {

	public GameObject groupie;

	void Start() {
		//for (int i = 0; i < 5; i++) {
			Instantiate(groupie);
		//} 
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D(Collision2D otherObj) {
		if (otherObj.gameObject.tag == "Stage") {
			Destroy(gameObject,.5f);
		}
	}
}
