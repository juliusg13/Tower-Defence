using UnityEngine;
using System.Collections;

public class GummyBearSound : MonoBehaviour {

	public AudioClip[] gummyClips;
	AudioSource gummySound;

	// Use this for initialization
	void Start () {
		gummySound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RandomGummyClip()
	{
		gummySound.clip = gummyClips[Random.Range(0,gummyClips.Length)];
		gummySound.Play ();
	}

}
