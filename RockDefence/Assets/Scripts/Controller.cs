using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Controller : MonoBehaviour {
	public bool isMenu;
	public int RockDollars;
	public int SpeakerPrice;
	public int BarPrice;
	public Text RockDollarText;
	public Text StageHealthText;
	public Text GameOverText;

	private StageScript stage;

	// Use this for initialization
	void Start () {
		SpeakerPrice = 10;
		BarPrice = 20;
		stage = GameObject.FindGameObjectWithTag ("Stage").GetComponent<StageScript>();
		isMenu = false;
		RockDollars = 100;
		GameOverText.text = "";
		RockDollarText.text = "Rock Dollars: " + RockDollars.ToString ();
		StageHealthText.text = "Band Moral: " + stage.StageHealth.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DisplayStageHealth(int StageHealth){
		StageHealthText.text = "Band Moral: " + StageHealth.ToString ();
	}

	public void GameOver(){
		GameOverText.text = "ROCK OVER";
	}

	public void BuySpeaker(){
		if(RockDollars > 0){
			RockDollars = RockDollars - SpeakerPrice;
			RockDollarText.text = "Rock Dollars: " + RockDollars.ToString ();
		}
	}

	public void BuyBar(){
		if(RockDollars > 0){
			RockDollars = RockDollars - BarPrice;
			RockDollarText.text = "Rock Dollars: " + RockDollars.ToString ();
		}
	}

	public void IncreaseRockDollars(){
		RockDollars = RockDollars + 2;
		RockDollarText.text = "Rock Dollars: " + RockDollars.ToString ();
	}
}
