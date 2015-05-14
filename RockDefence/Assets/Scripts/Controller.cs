using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;



public class Controller : MonoBehaviour {
	public int enemyCount;
	public bool isMenu;
	public bool GameLost;
	public bool nextLevel;
	public int RockDollars;
	public int SpeakerPrice;
	public int SpeakerUpgradePrice;
	public int BarPrice;
	public int BarUpgradePrice;
	public int LastLevel;
	public Text RockDollarText;
	public Text WinText;
	public Text StageHealthText;
	public Text GameOverText;
	public float x_coord_start;
	public float y_coord_start;
	public int level = 0;
	public bool GameOn = false;
	public CanvasGroup canvas;
	public CanvasGroup canvas2;
	private StageScript stage;
	public AudioClip boo;

	public GameObject mediumGroupie;
	public GameObject youngGroupie;
	public GameObject oldGroupie;


	AudioSource boosound;

	public class Level{
	public int levelNumber;
	public List<GroupOfGroupies> groupSequence;

	}

	public List<Level> LevelSequence;

		// Use this for initialization
	void Start () {

		canvas.alpha = 0;
		canvas.interactable = false;
		canvas2.alpha = 0;
		canvas2.interactable = false;
		enemyCount = 0;
		SpeakerPrice = 50;
		BarPrice = 60;
		stage = GameObject.FindGameObjectWithTag ("Stage").GetComponent<StageScript>();
		isMenu = false;
		RockDollars = 100;
		GameOverText.text = "";
		WinText.text = "";
		RockDollarText.text = "Rock Dollars: " + RockDollars.ToString ();
		StageHealthText.text = "Band Moral: " + stage.StageHealth.ToString();

		LevelSequence = new List<Level> ();

		Level One = new Level();
		One.groupSequence = new List<GroupOfGroupies> ();
		One.levelNumber = 1;
		One.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 5, 0, 1.6f));
		One.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 5, 0, 0.7f));
		LevelSequence.Add (One);

		Level Two = new Level ();
		Two.groupSequence = new List<GroupOfGroupies> ();
		Two.levelNumber = 2;
		Two.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 10, 0, 1.3f));
		Two.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 5, 1f, 0.7f));
		LevelSequence.Add (Two);

		Level Three = new Level ();
		Three.groupSequence = new List<GroupOfGroupies> ();
		Three.levelNumber = 3;
		Three.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 15, 0, 1.6f));
		Three.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 10, 0, 0.5f));
		Three.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 15, 0, 1.6f));
		LevelSequence.Add (Three);

		Level Four = new Level ();
		Four.groupSequence = new List<GroupOfGroupies> ();
		Four.levelNumber = 4;
		Four.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 20, 0, 0.5f));
		LevelSequence.Add (Four);

		Level Five = new Level ();
		Five.groupSequence = new List<GroupOfGroupies> ();
		Five.levelNumber = 5;
		Five.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 5, 0, 1.6f));
		Five.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 10, 0, 1.6f));
		LevelSequence.Add (Five);

		Level Six = new Level ();
		Six.groupSequence = new List<GroupOfGroupies> ();
		Six.levelNumber = 6;
		Six.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 10, 0, 1.6f));
		LevelSequence.Add (Six);

		Level Seven = new Level ();
		Seven.groupSequence = new List<GroupOfGroupies> ();
		Seven.levelNumber = 7;
		Seven.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 10, 0, 1.6f));
		LevelSequence.Add (Seven);

		Level Eight = new Level ();
		Eight.groupSequence = new List<GroupOfGroupies> ();
		Eight.levelNumber = 8;
		Eight.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 10, 0, 1.6f));
		LevelSequence.Add (Eight);

		Level Nine = new Level ();
		Nine.groupSequence = new List<GroupOfGroupies> ();
		Nine.levelNumber = 9;
		Nine.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 10, 0, 1.6f));
		LevelSequence.Add (Nine);

		Level Ten = new Level ();
		Ten.groupSequence = new List<GroupOfGroupies> ();
		Ten.levelNumber = 10;
		Ten.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 10, 0, 1.6f));
		Ten.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 20, 1, 1.6f));
		LevelSequence.Add (Ten);

	}
	// Update is called once per frame
	void Update () {
		WinLevel ();
	}
	
	public IEnumerator RunLevel(Level currentLevel)
	{

		float z = -1f;
//		this.GetComponent<AudioSource> ().Play ();
		//Nolvl = GameObject.FindGameObjectWithTag ("NumberOfLevel");
		//Nolvl.GetComponent<SpriteRenderer> ().sprite = Four; // fix with array

		List<GroupOfGroupies> currentGroupSequence = currentLevel.groupSequence;

		foreach (GroupOfGroupies group in currentGroupSequence) {

			yield return new WaitForSeconds(group.DelayTime);
			
			for (int i = 0; i < group.howMany; i++) {
				GameObject enemy;
				if(group.typeOfGroupie == "YoungGroupie"){
					enemy =  youngGroupie;
				}
				else if(group.typeOfGroupie == "MediumGroupie"){
					enemy =  mediumGroupie;
				}
				else{ //if(group.typeOfGroupie == "OldGroupie"){
					enemy =  oldGroupie;
				}

				Instantiate (enemy, new Vector3 (x_coord_start, y_coord_start, z), transform.rotation);
				enemyCount++;
				yield return new WaitForSeconds (group.separationTime);
			}
		}
		level++;
		GameOn = false;
	}

	void Levelspawner(){
	}

		
	public void DisplayStageHealth(int StageHealth){
		StageHealthText.text = "Band Morale: " + StageHealth.ToString ();
	}

	public void GameOver(){
		//setja boo í fall seinna
		boosound = GetComponent<AudioSource> ();
		boosound.clip = boo;
		boosound.Play ();
		GameOverText.text = "ROCK OVER";
		canvas.alpha = 1;
		canvas.interactable = true;
		//Time.timeScale = 0;
		GameLost = true;


	}

	public void WinLevel(){
		if (level == LastLevel && enemyCount == 0 && stage.StageHealth > 0) {
			WinText.text = "YOU ROCK!";
			canvas2.alpha = 1;
			canvas2.interactable = true;
			GameLost = true;
		}
	}

	public void DecreaseEnemyCount(){
		enemyCount--;
	}

	public void LoadNextLevel(){
		Application.LoadLevel (1);
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
	public void BuySpeakerUpgrade() {
		if (RockDollars >= SpeakerUpgradePrice) {
			RockDollars -= SpeakerUpgradePrice;
			RockDollarText.text = "Rock Dollars: " + RockDollars.ToString();
		}
	}

	public void BuyBar(){
		if(RockDollars >= BarPrice){
			RockDollars = RockDollars - BarPrice;
			RockDollarText.text = "Rock Dollars: " + RockDollars.ToString ();
		}
	}
	public void BuyBarUpgrade() {
		if (RockDollars >= BarUpgradePrice) {
			RockDollars -= BarUpgradePrice;
			RockDollarText.text = "Rock Dollars: " + RockDollars.ToString();
		}
	}

	public void IncreaseRockDollars(int Dollar){
		RockDollars = RockDollars + Dollar;
		RockDollarText.text = "Rock Dollars: " + RockDollars.ToString ();
	}
}
