using UnityEngine;
using System.Collections;

public class BuildMenu : MonoBehaviour {
	
	public GameObject speaker;
	public GameObject bar;
	public GameObject speakerUpgrade;
	public GameObject barUpgrade;
	public GameObject SourceTile;
	public GameObject Circle;
	public int SpeakerPrice;
	public int BarPrice;

	GameObject cont;
	Controller c;
	// Use this for initialization
	void Start () {
		SpeakerPrice = 10;
		BarPrice = 20;

		cont = GameObject.Find ("Controller");
		c = cont.GetComponent<Controller> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FindCircleAndDestroy(){
		if(GameObject.FindGameObjectWithTag("MenuChild")){
			Destroy (GameObject.FindGameObjectWithTag("MenuChild"));
		}
	}
	void FindMenuAndDestroy(){
		GameObject BM;
		GameObject OM;
		if(BM = GameObject.FindGameObjectWithTag ("MenuBarRange")) Destroy (BM);
		if(OM = GameObject.FindGameObjectWithTag ("MenuSpeakerRange")) Destroy (OM);
		c.isMenu = false;
	}

	void OnMouseDown() {

		
		bool isBuilt = SourceTile.GetComponent<Tile> ().built;
		
		float x = this.transform.position.x;
		float y = this.transform.position.y;
		
		if (c.isMenu == true) {
			if ((this.gameObject.tag == "MenuSpeakerRange") && (isBuilt == false) && (c.RockDollars >= c.SpeakerPrice)) {
				Instantiate (speaker, new Vector3 (x + 0.3f, y, 1), transform.rotation);
				SourceTile.GetComponent<Tile> ().built = true;
				
				FindCircleAndDestroy ();
				FindMenuAndDestroy ();
				
				c.BuySpeaker ();
			} else if (this.gameObject.tag == "MenuBarRange" && (isBuilt == false) && (c.RockDollars >= c.BarPrice)) {
				Instantiate (bar, new Vector3 (x - 0.3f, y, 1), transform.rotation);
				SourceTile.GetComponent<Tile> ().built = true;

				FindCircleAndDestroy ();
				FindMenuAndDestroy ();

				c.BuyBar ();
				//built = true;
			} else if(this.gameObject.tag == "UpgradeBlueMenu"){

			}




			/*else {
				FindCircleAndDestroy ();
				FindMenuAndDestroy ();
			}*/
		} /*else {
			FindCircleAndDestroy ();
			FindMenuAndDestroy ();
		}*/
		
	}
	
	void OnMouseEnter() {
		
		float x = SourceTile.GetComponent<Tile> ().transform.position.x;
		float y = SourceTile.GetComponent<Tile> ().transform.position.y;
		
		if (this.gameObject.tag == "MenuBarRange" || this.gameObject.tag == "MenuSpeakerRange") {
			//this.GetComponentInChildren<SpriteRenderer>().color = new Color(255f, 255f, 0, 1);
			GameObject Circle1 = (GameObject)Instantiate(Circle, new Vector3(x, y, -1), transform.rotation);
			Circle1.GetComponent<SpriteRenderer>().enabled = true;
		}
	}
	void OnMouseExit() {
		if (this.gameObject.tag == "MenuBarRange" || this.gameObject.tag == "MenuSpeakerRange") {
			//while(GameObject.FindGameObjectWithTag("MenuChild") != null){
			FindCircleAndDestroy();
			//}
		}
		
	}
}
