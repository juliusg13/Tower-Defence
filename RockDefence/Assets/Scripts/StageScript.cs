using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class StageScript : MonoBehaviour {

	public int StageHealth;
	public GameObject explosion;
	public AudioClip[] Grouppieclips;
	public AudioClip Grouppies;
	AudioSource Grouppiesound;
	Controller controller;

	// Use this for initialization
	void Start () {
		StageHealth = 10;
		controller = GameObject.FindGameObjectWithTag ("GameController").GetComponent<Controller>();
		Grouppiesound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.tag == "Destroy") {
			if(StageHealth > 0){
				StageHealth = StageHealth - 1;
				RandomPlayClip();
			}
			if(StageHealth == 0){
				Destroy(this.gameObject);
				Instantiate(explosion, transform.position, transform.rotation);
				controller.GameOver();
			}
			Destroy(other.gameObject);

			controller.DisplayStageHealth(StageHealth);

		}
	}
	public void RandomPlayClip()
	{
		Grouppiesound.clip = Grouppieclips[Random.Range(0,Grouppieclips.Length)];
		Grouppiesound.Play ();

		
	}
}
