using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
	
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "Groupie" || other.gameObject.name == "Groupie(Clone)" || 
		    other.gameObject.name == "YoungGroupie" || other.gameObject.name == "YoungGroupie(Clone)"|| 
		    other.gameObject.name == "OldGroupie" || other.gameObject.name == "OldGroupie(Clone)") {
			Destroy (this.gameObject);
			Destroy (other.gameObject);
			//Ekki deletea næstu 2 linum. Gott ad sja taer tvi taer virka til ad breyta public tolum i odrm scrips.
			//Move move = other.GetComponent<Move>();
			//move.moveSpeed -= 1; 
		}

	}
	// Update is called once per frame
	void Update () {

	}
	void FixedUpdate (){
		transform.Translate(new Vector3(0,speed*Time.deltaTime,0));
	}

}
