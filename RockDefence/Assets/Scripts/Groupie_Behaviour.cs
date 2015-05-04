using UnityEngine;
using System.Collections;

public class Groupie_Behaviour : MonoBehaviour {
	
	public float moveSpeed;
	public float health;

	int stopSpeed = 0;
	//int direction = 1; // 0 = West, 1 = South, 2 = East.
	string direction = "south"; 
	
	// Use this for initialization
	void Start () {
		if (this.gameObject.name == "Groupie") {
			moveSpeed = 0.4f;
			health = 2;
		} else if (this.gameObject.name == "YoungGroupie") {
			moveSpeed = 0.6f;
			health = 1;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void FixedUpdate (){
		
		if (direction == "east") {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (transform.localScale.x * moveSpeed, transform.localScale.y * stopSpeed);	
		} 
		else if (direction == "south") {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (transform.localScale.x * stopSpeed, -transform.localScale.y * moveSpeed);
		} 
		else if (direction == "west") {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-transform.localScale.x * moveSpeed, transform.localScale.y * stopSpeed);
		} 
		else if (direction == "north") {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-transform.localScale.x * stopSpeed, transform.localScale.y *moveSpeed);
		}
		
	}
	void OnTriggerEnter2D(Collider2D other){
		//Destroy (other.gameObject);
//		float xValue;
//		float yValue;//, zValue;
		if (other.gameObject.name == "Go_south") {
			//yValue = GetComponent<Rigidbody2D> ().position.y;
			//	zValue = GetComponent<Rigidbody2D> ().position.z;
			//xValue = GetComponent<Rigidbody2D> ().position.x - 0.01f;
			//transform.position = new Vector2 (xValue, yValue);
			direction = "south";
			transform.Rotate (0, 0, 90);
		} else if (other.gameObject.name == "Go_west") {
			
			//yValue = GetComponent<Rigidbody2D> ().position.y + 0.01f;
			//xValue = GetComponent<Rigidbody2D> ().position.x;
			//transform.position = new Vector2 (xValue, yValue);
			direction = "west";
			transform.Rotate (0, 0, -90);
		} else if (other.gameObject.name == "Go_east") {
			
			//yValue = GetComponent<Rigidbody2D> ().position.y;
			//xValue = GetComponent<Rigidbody2D> ().position.x - 0.01f;
			//transform.position = new Vector2 (xValue, yValue);
			direction = "east";
			transform.Rotate (0, 0, -90);
		} else if (other.gameObject.name == "Go_north") {
			direction = "north";
			transform.Rotate (0, 0, 90);
		} else if (other.gameObject.name == "Stage") {
			Destroy (this.gameObject);
		} else if (other.gameObject.tag == "Note") {
			health = health - 1;
			if(health <= 0){
				Destroy(this.gameObject);
			}
		}
		
	}
	
	void OnCollisionEnter2D(Collision2D colis)
	{
		//colis.transform.Rotate (Vector3.right);
		//colis.transform.Rotate (Vector3.up);
		//	transform.Rotate (0, 0, 90);
		//I tried .tag also but neither seemed to work
		//if (colis.gameObject.name == "Grass") {
		//	Debug.Log("hit");
		//	Destroy(colis.gameObject);
		//GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x,transform.localScale.y * moveSpeed);
		//GetComponent<Rigidbody2D> ().AddForce(transform.forward * 2);
		//}
	}
	
}
