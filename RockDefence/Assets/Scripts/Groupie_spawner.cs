using UnityEngine;
using System.Collections;

public class Groupie_spawner : MonoBehaviour {

	public GameObject groupie;
	//public GameObject YoungGroupie;
	public int Groupie_count;
	public float length_between_groupies;

	public float x_coord_start;
	public float y_coord_start;

	void Start() {

		float z = -1f;
		for (int i = 0; i < Groupie_count; i++) {
			Instantiate(groupie, new Vector3(x_coord_start, y_coord_start, z), transform.rotation);
			//Instantiate(YoungGroupie, new Vector3(x, y, z), transform.rotation);
			y_coord_start += length_between_groupies;
		} 
	}
	
	// Update is called once per frame

}
