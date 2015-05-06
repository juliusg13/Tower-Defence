using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class StageScript : MonoBehaviour {

	public int StageHealth;
	public Text GameOverText;
	public Button RestartButton;
	public GameObject explosion;

	// Use this for initialization
	void Start () {
		StageHealth = 10;
		GameOverText.text = "";

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.tag == "Destroy") {

			if(StageHealth == 0){
				Destroy(this.gameObject);
				Instantiate(explosion, transform.position, transform.rotation);
				GameOverText.text = "ROCK OVER";

			}
			Destroy(other.gameObject);
			StageHealth = StageHealth - 1;
		}
	}
}
