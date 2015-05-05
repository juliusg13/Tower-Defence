using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour {
	public float speed;

	public GameObject target;
	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Groupie" ) {
			Destroy (this.gameObject);
		}

	}

	
	// Update is called once per frame
	void Update () {
		
	}
	
	void FixedUpdate (){

		//while (target != null) {
		if (target == null) {				// if groupie does no longer exists then destroy the note that is following it
			Destroy (this.gameObject);
		}
		if (target != null) {
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, target.transform.position, step);
		}
			//transform.Translate(new Vector3(0,speed*Time.deltaTime,0));
		//}

	}
	
}