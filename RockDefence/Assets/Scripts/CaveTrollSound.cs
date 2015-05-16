using UnityEngine;
using System.Collections;

public class CaveTrollSound : MonoBehaviour {

	public AudioClip[] caveClips;
	AudioSource caveSound;

	// Use this for initialization
	void Start () {
		caveSound = GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {

	}
	public void RandomCaveClip()
	{
		caveSound.clip = caveClips [Random.Range (0, caveClips.Length)];
		caveSound.Play ();
	}
}
