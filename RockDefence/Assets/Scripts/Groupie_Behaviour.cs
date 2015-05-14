using UnityEngine;
using System.Collections;

public class Groupie_Behaviour : MonoBehaviour {
	
	public float moveSpeed;
	public float health;
	public bool drunk = false;
	public Quaternion rotation = Quaternion.identity;

	private Controller controller;

	int stopSpeed = 0;
	//int direction = 1; // 0 = West, 1 = South, 2 = East.
	string direction = "south"; 
	
	// Use this for initialization
	void Start () {
		controller = GameObject.FindGameObjectWithTag ("GameController").GetComponent<Controller>();

		
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
			} else if ((zrotation > -5) && (zrotation < 5)){
				transform.Rotate (0,0, 90);
			}
			else if ((zrotation > 175) && (zrotation < 185)){
				transform.Rotate (0,0, -90);
			}
			direction = "south";


		} 
		//Groupies turn west depending on their current rotation
		else if (other.gameObject.name == "Go_west") {

			float zrotation = transform.localRotation.eulerAngles.z;
			if (zrotation == 0) {
				transform.Rotate (0, 0, -90);
			} else if ((zrotation > 85) && (zrotation < 95)){
				transform.Rotate(0,0, -90);
			}
			else if ((zrotation > 175) && (zrotation < 185))
			{
				Debug.Log("Kalli");
				transform.Rotate (0, 0, 90);
			}
			direction = "west";

		} 
		//Groupies turn east depending on their current rotation
		else if (other.gameObject.name == "Go_east") {
			
			float zrotation = transform.localRotation.eulerAngles.z;
			if (zrotation == 0) {
				transform.Rotate (0, 0, 90);
			} else if (((zrotation > 175) && (zrotation < 185)) || ((zrotation > 265) && (zrotation < 275))) {
				transform.Rotate (0, 0, -90);
			} else if (((zrotation > 85) && (zrotation < 95))) {
				transform.Rotate (0, 0, +90);
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
			} else if ((zrotation > 175) && (zrotation < 185)) {
				transform.Rotate (0, 0, +90);
			}
			direction = "north";
		
		} else if (other.gameObject.name == "Stage") {
			Destroy (this.gameObject);
		
		//If the groupie faints you gain x amount of rock dollars
		} else if (other.gameObject.tag == "Note") {
			health = health - 1;
			Destroy (other.gameObject);

			if (health <= 0) {
				if(this.gameObject.name == "YoungGroupie(Clone)"){
					controller.IncreaseRockDollars(1);
				}
				if(this.gameObject.name == "MediumGroupie(Clone)") {
					controller.IncreaseRockDollars(2);
				}
				if(this.gameObject.name == "OldGroupie(Clone)"){
					controller.IncreaseRockDollars(3);
				}
				if(this.gameObject.name == "Tank_boss(Clone)"){
					controller.IncreaseRockDollars(20);
				}
				Destroy (this.gameObject);
				controller.DecreaseEnemyCount();
				//controller.IncreaseRockDollars();
			}
		} else if (other.gameObject.tag == "Beer") {

			//if (moveSpeed > 0.3f)
			//{
				//Shooting gScript = other.GetComponent<Shooting>();
				//if(gScript != null)
				//{
				
					StartCoroutine(Slow ());
					//Debug.Log("Dec");
					//moveSpeed -= gScript.slowing;
				//}
			//}

		}
		
	}
	IEnumerator Slow()
	{

		moveSpeed = moveSpeed / 2;
		yield return new WaitForSeconds (2);
		moveSpeed = moveSpeed * 2;

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
