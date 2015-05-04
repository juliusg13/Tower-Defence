using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shooting : MonoBehaviour {
	
	public GameObject Note; //Returns an error because it is not initialized
	public float fireRate = 0.5f;
	public double nextShot = 0.9;
	public bool allowFire = true;
	
	public List<GameObject> ObjectsInRange = new List<GameObject>();
	
	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void FixedUpdate (){
		
		if ( allowFire && (ObjectsInRange.Count > 0)) {
			StartCoroutine(Fire ());
		}
		/*if (Time.time >= nextShot) {
			Instantiate (shootingPref, new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			nextShot = Time.time + fireRate;
		}*/
		
	}
	IEnumerator Fire()
	{
		Debug.Log ("Fire");
		allowFire = false;
		GameObject blah = (GameObject)Instantiate (Note, new Vector3 (transform.position.x , transform.position.y, transform.position.z), Quaternion.identity);
		blah.GetComponent<Note>().target = ObjectsInRange[0];
		yield return new WaitForSeconds (1);
		Debug.Log ("Fire2");
		allowFire = true;
	}
	
	void OnTriggerEnter2D(Collider2D other){
		
		ObjectsInRange.Add (other.gameObject);
		Debug.Log (ObjectsInRange[0]);
		
		
	}
	void OnTriggerExit2D(Collider2D other)
	{
		ObjectsInRange.Remove (other.gameObject);
	}
}
