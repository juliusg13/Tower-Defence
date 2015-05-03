using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	
	public float moveSpeed;
	int stopSpeed = 0;
	//int direction = 1; // 0 = West, 1 = South, 2 = East.
	string direction = "south"; 
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void FixedUpdate (){
		
		if (direction == "east") {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (transform.localScale.x * moveSpeed, transform.localScale.y * stopSpeed);
			
		} else if (direction == "south") {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (transform.localScale.x * stopSpeed, -transform.localScale.y * moveSpeed);
		}
		else if (direction == "west") {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-transform.localScale.x * moveSpeed, transform.localScale.y * stopSpeed);
		}
		
		
	}
	void OnTriggerEnter2D(Collider2D other){
		//Destroy (other.gameObject);
//		float xValue;
//		float yValue;//, zValue;
		if (other.gameObject.name == "GoSouth") {
			//yValue = GetComponent<Rigidbody2D> ().position.y;
			//	zValue = GetComponent<Rigidbody2D> ().position.z;
			//xValue = GetComponent<Rigidbody2D> ().position.x - 0.01f;
			//transform.position = new Vector2 (xValue, yValue);
			direction = "south";
			transform.Rotate (0, 0, 90);
		} else if (other.gameObject.name == "GoWest") {
			
			//yValue = GetComponent<Rigidbody2D> ().position.y + 0.01f;
			//xValue = GetComponent<Rigidbody2D> ().position.x;
			//transform.position = new Vector2 (xValue, yValue);
			direction="west";
			transform.Rotate(0,0,-90);
		}
		else if(other.gameObject.name == "GoEast") {
			
			//yValue = GetComponent<Rigidbody2D> ().position.y;
			//xValue = GetComponent<Rigidbody2D> ().position.x - 0.01f;
			//transform.position = new Vector2 (xValue, yValue);
			direction="east";
			transform.Rotate(0,0,-90);
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
