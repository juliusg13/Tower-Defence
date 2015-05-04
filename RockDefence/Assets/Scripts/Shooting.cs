using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

	public Transform shootingPref; //Returns an error because it is not initialized
	public double fireRate = 0.5;

	public double nextShot = 0.0; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate (){
		/*if (Time.time >= nextShot) {
			Instantiate (shootingPref, new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			nextShot = Time.time + fireRate;
		}*/

	}
	void OnTriggerEnter2D(Collider2D other){
		if (Time.time >= nextShot) {
			Instantiate (shootingPref, new Vector3 (transform.position.x , transform.position.y, transform.position.z), Quaternion.identity);
			nextShot = Time.time + fireRate;
		}
		
	}
}
