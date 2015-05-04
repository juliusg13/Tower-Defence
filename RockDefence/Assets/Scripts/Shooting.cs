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

		if ( allowFire && (ObjectsInRange.Count > 0)) {
			StartCoroutine(Fire ());
		}
		/*if (Time.time >= nextShot) {
			Instantiate (shootingPref, new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			nextShot = Time.time + fireRate;
		}*/

	}


	IEnumerator Fire()
	{
		Debug.Log ("Fire");
		allowFire = false;
		GameObject blah = (GameObject)Instantiate (Note, new Vector3 (transform.position.x , transform.position.y, transform.position.z), Quaternion.identity);
		blah.GetComponent<Note>().target = ObjectsInRange[0];
		yield return new WaitForSeconds (1);
		Debug.Log ("Fire2");
		allowFire = true;
	}
	
	void OnTriggerEnter2D(Collider2D other){

		ObjectsInRange.Add (other.gameObject);
		Debug.Log (ObjectsInRange[0]);

	}

	void OnTriggerExit2D(Collider2D other)
	{
		ObjectsInRange.Remove (other.gameObject);
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