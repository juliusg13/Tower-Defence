using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {

	public GameObject Note;
	public Transform shotSpawn;
	public float fireRate;
	// Use this for initialization
	public float HitRatio;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void FixedUpdate(){
		Instantiate(Note, shotSpawn.position, shotSpawn.rotation);
	}
}
