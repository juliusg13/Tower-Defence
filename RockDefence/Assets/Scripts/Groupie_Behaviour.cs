using UnityEngine;
using System.Collections;

public class Groupie_Behaviour : MonoBehaviour {
	
	public float moveSpeed;
	public float health;
	public Quaternion rotation = Quaternion.identity;

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
			health = 5;
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


		//Groupies turn south depending on their current rotation
		if (other.gameObject.name == "Go_south") {
			float zrotation = transform.localRotation.eulerAngles.z;
			if (zrotation == 270) {
				transform.Rotate (0, 0, +90);
			} else if ((zrotation > 85) && (zrotation < 95)) {
				transform.Rotate (0, 0, -90);
			}
			direction = "south";


		} 
		//Groupies turn west depending on their current rotation
		else if (other.gameObject.name == "Go_west") {

			float zrotation = transform.localRotation.eulerAngles.z;
			if (zrotation == 0) {
				transform.Rotate (0, 0, -90);
			}
			direction = "west";

		} 
		//Groupies turn east depending on their current rotation
		else if (other.gameObject.name == "Go_east") {
			
			float zrotation = transform.localRotation.eulerAngles.z;
			if (zrotation == 0) {
				transform.Rotate (0, 0, 90);
			} else if ((zrotation > 178) && (zrotation < 182)) {
				transform.Rotate (0, 0, -90);
			}
			direction = "east";

		} 
		//Groupies turn north depending on their current rotation
		else if (other.gameObject.name == "Go_north") {
			float zrotation = transform.localRotation.eulerAngles.z;
			if (zrotation == 270) {
				transform.Rotate (0, 0, -90);
			} else if ((zrotation > 85) && (zrotation < 95)) {
				transform.Rotate (0, 0, 90);
			}
			direction = "north";
		
		} else if (other.gameObject.name == "Stage") {
			Destroy (this.gameObject);
		} else if (other.gameObject.tag == "Note") {
			health = health - 1;
			Destroy (other.gameObject);
			if (health <= 0) {
				Destroy (this.gameObject);
			}
		} else if (other.gameObject.tag == "Beer") {
			if (moveSpeed > 0.3f)
			{
				Shooting gScript = other.GetComponent<Shooting>();
				if(gScript != null)
				{
					moveSpeed -= gScript.slowing;
				}
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
