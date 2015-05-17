using UnityEngine;
using System.Collections;

public class SellSound : MonoBehaviour {

	public AudioClip[] sellClips;
	AudioSource sellSound;
	
	// Use this for initialization
	void Start () {
		sellSound = GetComponent<AudioSource> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void RandomSellClip()
	{
		sellSound.clip = sellClips [Random.Range (0, sellClips.Length)];
		sellSound.Play ();
	}
}
