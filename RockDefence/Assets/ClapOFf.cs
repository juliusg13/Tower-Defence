using UnityEngine;
using System.Collections;

public class ClapOFf : MonoBehaviour {
	AudioSource clapSound;
	bool clapOn;
	// Use this for initialization
	void Start () {
		clapSound = GetComponent<AudioSource> ();
		clapSound.Play ();
	}
	
	// Update is called once per frame
	void Update () {


	}
}
