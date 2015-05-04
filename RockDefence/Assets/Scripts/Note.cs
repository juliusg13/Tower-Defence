using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour {
	public float speed;
	public GameObject target;

	// Use this for initialization
	void Start () {
	
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "Groupie" || other.gameObject.name == "Groupie(Clone)") {
			Destroy (this.gameObject);
		}
	}

	// Update is called once per frame
	void Update () {

	}
	void FixedUpdate (){
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
		//transform.Translate(new Vector3(0,speed*Time.deltaTime,0));
	}

}
