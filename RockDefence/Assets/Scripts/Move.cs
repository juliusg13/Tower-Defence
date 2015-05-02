using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	public float moveSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate (){
		//GetComponent<Rigidbody2D> ().velocity = new Vector2 (transform.localScale.x * moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
	
		//BARA FLIPP MEÐ IF OG ELSE EIGUM SENNILEGA eKKI að GERA ÞETTA SVONA

		if (GetComponent<Rigidbody2D> ().position.x < -1.9) {
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

		}
	}
	void OnCollisionEnter(Collision colis)
	{
		//I tried .tag also but neither seemed to work
		if (colis.gameObject.name == "Grass") {
			Debug.Log("hit");
			Destroy(colis.gameObject);
			//GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x,transform.localScale.y * moveSpeed);
			//GetComponent<Rigidbody2D> ().AddForce(transform.forward * 2);
		}
	}

}
