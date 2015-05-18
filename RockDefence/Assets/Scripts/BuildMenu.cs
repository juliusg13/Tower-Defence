using UnityEngine;
using System.Collections;

public class BuildMenu : MonoBehaviour {
	
	public GameObject speaker;
	public GameObject bar;
	public GameObject speakerUpgrade;
	public GameObject barUpgrade;
	public GameObject SourceTile;
	public GameObject Circle;
	public GameObject BigCircle;
	SellSound sellSound;	
	
	GameObject cont;
	Controller c;
	
	// Use this for initialization
	void Start () {
		cont = GameObject.Find ("Controller");
		c = cont.GetComponent<Controller> ();
		sellSound = GameObject.FindGameObjectWithTag ("SellSoundTag").GetComponent<SellSound>();

	}
	// Update is called once per frame
	void Update () {
		
	}
	
	void FindCircleAndDestroy(){
		GameObject[] Circles = GameObject.FindGameObjectsWithTag ("MenuChild");
		for (int i = 0; i < Circles.Length; i++) {
			Destroy(Circles[i]);
		}
	}
	void FindMenuAndDestroy(){
		GameObject BM, OM, BUM, OUM, SELL;
		
		if(BM = GameObject.FindGameObjectWithTag ("MenuBarRange")) Destroy (BM);
		if(OM = GameObject.FindGameObjectWithTag ("MenuSpeakerRange")) Destroy (OM);
		if (BUM = GameObject.FindGameObjectWithTag ("BlueUpgradeMenu")) Destroy (BUM);
		if (OUM = GameObject.FindGameObjectWithTag ("OrangeUpgradeMenu")) Destroy (OUM);
		if (SELL = GameObject.FindGameObjectWithTag ("SellTower")) Destroy (SELL);

		c.isMenu = false;
	}
	
	void DestroyTower(GameObject tower){
		Destroy (tower);
	}
	
	void OnMouseDown() {
		
		
		bool isBuilt;
		if (this.SourceTile.GetComponent<Tile> ().built) {
			isBuilt = true; 
		} else {
			isBuilt = false;
		}
		
		float x = this.transform.position.x;
		float y = this.transform.position.y;
		float d = 0;
		
		if (c.isMenu == true) {
			//Debug.Log(this.tag);
			if (this.gameObject.tag == "SellTower"){
				//Destroy (this);
				sellSound.RandomSellClip();
						string F = SourceTile.tag;
				if(F == "Speaker") d = c.SpeakerPrice;
				if(F == "BarShootStraight") d = c.BarPrice;
				if(F == "Upgrade") d = c.BarUpgradePrice;
				if(F == "SpeakerUpgrade") d = c.SpeakerUpgradePrice;
				d *= 0.5f;
				int dollars = (int)Mathf.Round(d);
				c.IncreaseRockDollars(dollars);

				SourceTile.GetComponent<Tile>().built = false;
				DestroyTower (SourceTile.GetComponent<Tile>().towerOnTile);
				
				FindMenuAndDestroy();
				FindCircleAndDestroy();
				
				SourceTile.GetComponent<Tile>().tag = "Buildable";
				
			}
			else if ((this.gameObject.tag == "MenuSpeakerRange") && (isBuilt == false) && (c.RockDollars >= c.SpeakerPrice)) {
				GameObject ThisBar = (GameObject)Instantiate (speaker, new Vector3 (x + 0.3f, y, 1), transform.rotation);
				SourceTile.GetComponent<Tile> ().built = true;
				FindCircleAndDestroy ();
				FindMenuAndDestroy ();
				
				SourceTile.GetComponent<Tile> ().tag = "Speaker";
				SourceTile.GetComponent<Tile> ().towerOnTile = ThisBar;
				
				c.BuySpeaker ();
			} else if (this.gameObject.tag == "MenuBarRange" && (isBuilt == false) && (c.RockDollars >= c.BarPrice)) {
				GameObject ThisBar = (GameObject)Instantiate (bar, new Vector3 (x - 0.3f, y, 1), transform.rotation);
				SourceTile.GetComponent<Tile> ().built = true;
				FindCircleAndDestroy ();
				FindMenuAndDestroy ();
				
				SourceTile.GetComponent<Tile> ().tag = "BarShootStraight";
				SourceTile.GetComponent<Tile> ().towerOnTile = ThisBar;
				
				c.BuyBar ();
				//built = true;
			} else if(this.gameObject.tag == "BlueUpgradeMenu" && (c.RockDollars >= c.BarUpgradePrice)){
				DestroyTower(SourceTile.GetComponent<Tile>().towerOnTile);
				
				FindMenuAndDestroy();
				FindCircleAndDestroy();
				
				GameObject ThisBar = (GameObject)Instantiate(barUpgrade, new Vector3(x+0.35f,y-0.15f, 1), transform.rotation);
				SourceTile.GetComponent<Tile>().tag = "Upgrade";
				SourceTile.GetComponent<Tile>().towerOnTile = ThisBar;

				c.BuyBarUpgrade();
			} else if (tag == "OrangeUpgradeMenu" && (c.RockDollars >= c.SpeakerUpgradePrice)){
				DestroyTower (SourceTile.GetComponent<Tile>().towerOnTile);
				
				FindMenuAndDestroy();
				FindCircleAndDestroy();
				
				GameObject ThisBar = (GameObject)Instantiate(speakerUpgrade, new Vector3(x+0.35f, y-0.15f, 1), transform.rotation);
				SourceTile.GetComponent<Tile>().tag = "SpeakerUpgrade";
				SourceTile.GetComponent<Tile>().towerOnTile = ThisBar;
				c.BuySpeakerUpgrade();
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
			GameObject Circle1 = (GameObject)Instantiate (Circle, new Vector3 (x, y, -1), transform.rotation);
			Circle1.GetComponent<SpriteRenderer> ().enabled = true;
		} else if (this.gameObject.tag == "OrangeUpgradeMenu") {
			GameObject Circle1 = (GameObject)Instantiate (BigCircle, new Vector3 (x, y, -1), transform.rotation);
			Circle1.GetComponent<SpriteRenderer> ().enabled = true;
		}
	}
	void OnMouseExit() {
		if (this.gameObject.tag == "MenuBarRange" || this.gameObject.tag == "MenuSpeakerRange" || this.tag == "OrangeUpgradeMenu") {
			//while(GameObject.FindGameObjectWithTag("MenuChild") != null){
			FindCircleAndDestroy();
			//}
		}
		
	}
}
