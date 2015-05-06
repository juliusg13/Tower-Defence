using UnityEngine;
using System.Collections;

public class BuildMenu : MonoBehaviour {

	public GameObject speaker;
	public GameObject bar;
	public GameObject SourceTile;
	public int SpeakerPrice;
	public int BarPrice;
	// Use this for initialization
	void Start () {
		SpeakerPrice = 10;
		BarPrice = 20;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown() {
		GameObject cont = GameObject.Find ("Controller");
		Controller c = cont.GetComponent<Controller> ();

		bool isBuilt = SourceTile.GetComponent<Tile> ().built;

		float x = this.transform.position.x;
		float y = this.transform.position.y;

		if (c.isMenu == true) {
			if((this.gameObject.name == "Orange box(Clone)") && isBuilt == false){
				GameObject BM = GameObject.Find ("Blue box(Clone)");
				Instantiate(speaker, new Vector3(x+0.3f, y, 1), transform.rotation);
				Destroy(this.gameObject);
				Destroy (BM);
				c.isMenu = false;
				SourceTile.GetComponent<Tile> ().built = true;

				if(c.RockDollars > 0){
					c.RockDollars = c.RockDollars - SpeakerPrice;
					c.RockDollarText.text = "Rock Dollars: " + c.RockDollars.ToString ();
				}
					
				//built = true;
			}
			else if(this.gameObject.name == "Blue box(Clone)" && isBuilt == false){
				GameObject OM = GameObject.Find ("Orange box(Clone)");
				Instantiate (bar, new Vector3(x-0.3f,y,1), transform.rotation);
				Destroy(this.gameObject);
				Destroy (OM);
				c.isMenu = false;
				SourceTile.GetComponent<Tile> ().built = true;

				if(c.RockDollars > 0){
					c.RockDollars = c.RockDollars - BarPrice;
					c.RockDollarText.text = "Rock Dollars: " + c.RockDollars.ToString ();
				}
				//built = true;
			}

			
		}

	}
}
