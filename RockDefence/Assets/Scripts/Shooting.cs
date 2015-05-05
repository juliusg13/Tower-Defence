using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Shooting : MonoBehaviour {
	
	public GameObject Note; //Returns an error because it is not initialized
	public float fireRate = 0.5f;
	public double nextShot = 0.9;
	public bool allowFire = true;
	
	public List<GameObject> ObjectsInRange = new List<GameObject>();
	
	
	
	// Use this for initialization
	void Start () {
		
	}
	// GameObject closestGameObject = GameObject.FindGameObjectsWithTag("MyTag")
	//	.OrderBy(go => Vector3.Distance(go.transform.position, transform.position)
	//	         .FirstOrDefault();
	// Update is called once per frame
	void Update () {
		
	}
	
	
	void FixedUpdate (){
		if(ObjectsInRange.Count() > 0){

			if (ObjectsInRange.FirstOrDefault ().Equals (null)) { // If it is NULL then it has been destroyed
				ObjectsInRange.Remove(ObjectsInRange.FirstOrDefault ());
			}
		}
		if ( allowFire && (ObjectsInRange.Count > 0)) { //Locks out for a time corresponding to fireRate
			StartCoroutine(Fire ());					//For IEnumerator.. not a function
		}

	}

	IEnumerator Fire()
	{
		
		allowFire = false;
		GameObject newNote = (GameObject)Instantiate (Note, new Vector3 (transform.position.x , transform.position.y, transform.position.z), Quaternion.identity);
		newNote.GetComponent<Note>().target = ObjectsInRange.FirstOrDefault();
		yield return new WaitForSeconds (fireRate);
		allowFire = true;
	}
	
	void OnTriggerEnter2D(Collider2D other){		//Groupie enters the range of a speaker
		ObjectsInRange.Add (other.gameObject);

	}
	
	void OnTriggerExit2D(Collider2D other)			//Groupie exits the range of a speaker
	{
		if (other.gameObject.tag == "Destroy") {	
			Debug.Log ("DestroyGroup");
			ObjectsInRange.Remove (other.gameObject);
		}
			
		if (other.gameObject.tag == "Note") {	//Note Exits the range of the speaker, 
			Destroy (other.gameObject);	
			Debug.Log ("DestroyNote");
			//does not work maybe because note never collides 
			//with speaker to begin with
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