using UnityEngine;
using System.Collections;

public class Groupie_spawner : MonoBehaviour {

	public GameObject groupie;

	void Start() {
		float x = 1f;
		float y = 6f;
		float z = -1f;
		for (int i = 0; i < 5; i++) {
			Instantiate(groupie, new Vector3(x, y, z), transform.rotation);
			y += 0.9f;
		} 
	}
	
	// Update is called once per frame

}
