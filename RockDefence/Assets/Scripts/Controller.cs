using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;



public class Controller : MonoBehaviour {
	public bool isMenu;
	public bool GameLost;
	public int RockDollars;
	public int SpeakerPrice;
	public int BarPrice;
	public Text RockDollarText;
	public Text StageHealthText;
	public Text GameOverText;
	public float x_coord_start;
	public float y_coord_start;
	public int level = 0;
	public bool GameOn = false;
	public CanvasGroup canvas;
	private StageScript stage;

	public GameObject mediumGroupie;
	public GameObject youngGroupie;
	public GameObject oldGroupie;

	public class Level{
		public int levelNumber;
		public List<GroupOfGroupies> groupSequence;

	}

	public List<Level> LevelSequence;

		// Use this for initialization
	void Start () {



		canvas.alpha = 0;
		canvas.interactable = false;
		SpeakerPrice = 50;
		BarPrice = 60;
		stage = GameObject.FindGameObjectWithTag ("Stage").GetComponent<StageScript>();
		isMenu = false;
		RockDollars = 100;
		GameOverText.text = "";
		RockDollarText.text = "Rock Dollars: " + RockDollars.ToString ();
		StageHealthText.text = "Band Moral: " + stage.StageHealth.ToString();
		LevelSequence = new List<Level> ();
		Level One = new Level();
		One.groupSequence = new List<GroupOfGroupies> ();
		One.levelNumber = 1;
		One.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 5, 0, 0.7f));
		One.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 2, 3f, 0.3f));
		LevelSequence.Add (One);
		Level Two = new Level ();
		Two.groupSequence = new List<GroupOfGroupies> ();
		Two.levelNumber = 2;
		Two.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 1, 0, 0.7f));
		Two.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 10, 2, 0.7f));
		LevelSequence.Add (Two);

	}
	// Update is called once per frame
	void Update () {
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
				else //(group.typeOfGroupie == "OldGroupie")
				{
					enemy =  oldGroupie;
				}

				Instantiate (enemy, new Vector3 (x_coord_start, y_coord_start, z), transform.rotation);
				yield return new WaitForSeconds (group.separationTime);
			}



		}

		level++;

		Debug.Log (level);
		GameOn = (false);

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

	public void IncreaseRockDollars(int Dollar){
		RockDollars = RockDollars + Dollar;
		RockDollarText.text = "Rock Dollars: " + RockDollars.ToString ();
	}
}
