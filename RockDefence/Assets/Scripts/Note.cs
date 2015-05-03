using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
	
	}
	void OnCollisionEnter2D(Collision2D otherObj) {
		if (otherObj.gameObject.tag == "Hurtable") {
			//Destroy(otherObj.gameObject);
		}
	}
	// Update is called once per frame
	void Update () {

	}
	void FixedUpdate (){
		transform.Translate(new Vector3(0,speed*Time.deltaTime,0));
	}

}
