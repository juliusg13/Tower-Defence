using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour {
	public float speed;
	public Vector3 initialPos;
	public GameObject target;

	public float radius;
	// Use this for initialization
	void Start () {

	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Destroy" ) {
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
		if (transform.position.x > initialPos.x + 2*radius || transform.position.y > initialPos.y + 2*radius || transform.position.x < initialPos.x - 2*radius || transform.position.y < initialPos.y - 2*radius) {
			Destroy (this.gameObject);
		}
			//transform.Translate(new Vector3(0,speed*Time.deltaTime,0));
		//}

	}
	
}