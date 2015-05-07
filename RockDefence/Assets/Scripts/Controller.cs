using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Controller : MonoBehaviour {
	public bool isMenu;
	public bool GameLost;
	public int RockDollars;
	public int SpeakerPrice;
	public int BarPrice;
	public Text RockDollarText;
	public Text StageHealthText;
	public Text GameOverText;
	public int Level;

	public CanvasGroup canvas;
	private StageScript stage;
	
		
		// Use this for initialization
	void Start () {
		canvas.alpha = 0;
		canvas.interactable = false;
		SpeakerPrice = 10;
		BarPrice = 20;
		stage = GameObject.FindGameObjectWithTag ("Stage").GetComponent<StageScript>();
		isMenu = false;
		RockDollars = 100;
		GameOverText.text = "";
		RockDollarText.text = "Rock Dollars: " + RockDollars.ToString ();
		StageHealthText.text = "Band Moral: " + stage.StageHealth.ToString();
		Level = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Levelspawner(){


	}

	public void DisplayStageHealth(int StageHealth){
		StageHealthText.text = "Band Moral: " + StageHealth.ToString ();
	}

	public void GameOver(){
		GameOverText.text = "ROCK OVER";
		canvas.alpha = 1;
		canvas.interactable = true;
		//Time.timeScale = 0;
		GameLost = true;
	}

	public void RestartLevel(){
		Application.LoadLevel(Application.loadedLevel);
	}

	public void BuySpeaker(){
		if (RockDollars >= SpeakerPrice) {
			RockDollars = RockDollars - SpeakerPrice;
			RockDollarText.text = "Rock Dollars: " + RockDollars.ToString ();
		}
	}

	public void BuyBar(){
		if(RockDollars >= BarPrice){
			RockDollars = RockDollars - BarPrice;
			RockDollarText.text = "Rock Dollars: " + RockDollars.ToString ();
		}
	}

	public void IncreaseRockDollars(){
		RockDollars = RockDollars + 2;
		RockDollarText.text = "Rock Dollars: " + RockDollars.ToString ();
	}
}
