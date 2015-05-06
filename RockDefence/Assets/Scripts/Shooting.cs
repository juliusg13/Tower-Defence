using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Shooting : MonoBehaviour {
	
	public GameObject Note; //Returns an error because it is not initialized
	public float fireRate = 0.5f;
	public double nextShot = 0.9;
	public bool allowFire = true;
	public float slowing = 0;
	//public float radius = transform.GetComponent<CircleCollider2D>().radius;
	public List<GameObject> ObjectsInRange = new List<GameObject>();
	
	
	
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		
	}
	
	
	void FixedUpdate (){
		if(ObjectsInRange.Count() > 0){

			if (ObjectsInRange.FirstOrDefault ().Equals (null)) { // If it is NULL then it has been destroyed
				ObjectsInRange.Remove(ObjectsInRange.FirstOrDefault ());
			}
		}
		if ( allowFire && (ObjectsInRange.Count > 0) && this.gameObject.tag == "BarShootStraight") { //Locks out for a time corresponding to fireRate
			StartCoroutine(Fire ());					//For IEnumerator.. not a function
		}
		if ( allowFire && (ObjectsInRange.Count > 0) && this.gameObject.tag == "Speaker") { //Locks out for a time corresponding to fireRate
			StartCoroutine(Fire ());					//For IEnumerator.. not a function
		}
		
		
	}

	IEnumerator Fire()
	{
		
		allowFire = false;
		GameObject newNote = (GameObject)Instantiate (Note, new Vector3 (transform.position.x , transform.position.y, transform.position.z), Quaternion.identity);
		newNote.GetComponent<Note>().target = ObjectsInRange.FirstOrDefault();
		newNote.GetComponent<Note> ().initialPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		newNote.GetComponent<Note>().radius = this.GetComponent<CircleCollider2D>().radius;
		yield return new WaitForSeconds (fireRate);
		allowFire = true;
	}

		
	
	void OnTriggerEnter2D(Collider2D other){		//Groupie enters the range of a speaker

		if (other.gameObject.tag == "Destroy") {	

			ObjectsInRange.Add (other.gameObject);
		}
		if (this.gameObject.tag == "BarAoE") {
			Groupie_Behaviour gScript = other.GetComponent<Groupie_Behaviour>();
			gScript.moveSpeed -= slowing;
			//other.gameObject.moveSpeed -= 0.5;
		}
	}
	
	void OnTriggerExit2D(Collider2D other)			//Groupie exits the range of a speaker
	{

		if (other.gameObject.tag == "Destroy") {	
			ObjectsInRange.Remove (other.gameObject);
		}
		else if (other.gameObject.tag == "Note") {	//Note Exits the range of the speaker, 
			Debug.Log ("DestroyGroup");
			Destroy(other.gameObject);			//does not work maybe because note never collides 
												//with speaker to begin with
		}
		if (this.gameObject.tag == "BarAoE") {
			Groupie_Behaviour gScript = other.GetComponent<Groupie_Behaviour>();
			gScript.moveSpeed += slowing;
			//other.gameObject.moveSpeed -= 0.5;
		}
			

	}

	//public void AddEnemiesToList()
	//{
	//	GameObject[] ItemsInList = GameObject.FindGameObjectsWithTag("Destroy");
	//	foreach(GameObject _Enemy in ItemsInList)
	//	{
	//		AddTarget(_Enemy.transform);
	//	}
	//}
}





//using UnityEngine;
//		using System.Collections;
//		using System.Collections.Generic;
//		
//		public class Turret : MonoBehaviour {
//			public List <Transform> Enemies;
//			public Transform SelectedTarget;
//			
//			void Start () 
//			{
//				SelectedTarget = null;
//				Enemies = new List<Transform>();
//				AddEnemiesToList();
//			}
//			
//			
//			
//			public void AddTarget(Transform enemy)
//			{
//				Enemies.Add(enemy);
//			}
//			
//			public void DistanceToTarget()
//			{
//				Enemies.Sort(delegate( Transform t1, Transform t2){ 
//					return Vector3.Distance(t1.transform.position,transform.position).CompareTo(Vector3.Distance(t2.transform.position,transform.position)); 
//				});
//				
//			}
//			
//			public void TargetedEnemy() 
//			{
//				if(SelectedTarget == null)
//				{
//					DistanceToTarget();
//					SelectedTarget = Enemies[0];
//				}
//				
//				
//			}
//			
//			void Update () 
//			{
//				TargetedEnemy();
//				float dist = Vector3.Distance(SelectedTarget.transform.position,transform.position);
//				//if(dist <150)
//				//{
//				transform.position = Vector3.MoveTowards(transform.position, SelectedTarget.position, 60 * Time.deltaTime);
//				//}
//				
//			}
//		}