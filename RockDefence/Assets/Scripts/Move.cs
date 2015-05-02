using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	public float moveSpeed;
	int Direction = 0; // 0=right, 1 = up, 2 = down, 4 = left.
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate (){

		if (Direction == 0) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (transform.localScale.x * moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		} else if (Direction == 2) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, -transform.localScale.x *moveSpeed);
		}
	//	transform.Rotate (0, 0, 10);
		//BARA FLIPP MEÐ IF OG ELSE EIGUM SENNILEGA eKKI að GERA ÞETTA SVONA

	/*	if (GetComponent<Rigidbody2D> ().position.x < -1.9) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (transform.localScale.x * moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		}
		else if (GetComponent<Rigidbody2D> ().position.y < 0.55) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (transform.localScale.x *moveSpeed, transform.localScale.y * 0 );
			
		}
		else if (GetComponent<Rigidbody2D> ().position.x > -1.9) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (transform.localScale.x *0, -transform.localScale.y * moveSpeed );

		}
		else {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (transform.localScale.x * 0, GetComponent<Rigidbody2D> ().velocity.y);

		}*/
	}
	void OnTriggerEnter2D(Collider2D other){
		//Destroy (other.gameObject);
		float xValue;
		float yValue;//, zValue;
		yValue = GetComponent<Rigidbody2D> ().position.y;
	//	zValue = GetComponent<Rigidbody2D> ().position.z;
		xValue = GetComponent<Rigidbody2D> ().position.x - 0.05f;
		transform.position = new Vector2(xValue, yValue);
		Direction = 2;
		transform.Rotate (0, 0, 90);


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
