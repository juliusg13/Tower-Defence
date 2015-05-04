using UnityEngine;
using System.Collections;

public class Groupie_spawner : MonoBehaviour {

	public GameObject groupie;
	public GameObject YoungGroupie;
	public GameObject OldGroupie;
	public int Groupie_count;
	public float length_between_groupies;

	void Start() {
		float x = 1f;
		float y = 6f;
		float z = -1f;
		for (int i = 0; i < Groupie_count; i++) {
			Instantiate(groupie, new Vector3(x, y, z), transform.rotation);
			Instantiate(YoungGroupie, new Vector3(x, y, z), transform.rotation);
			Instantiate(OldGroupie, new Vector3(x, y, z), transform.rotation);
			y += length_between_groupies;
		} 
	}
	
	// Update is called once per frame

}
