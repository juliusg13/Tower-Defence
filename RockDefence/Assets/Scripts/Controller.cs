using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class Controller : MonoBehaviour {

	public bool isMenu;
	public bool GameLost;
	public bool nextLevel;
	public int enemyCount;
	public bool EnemyStop;
	public int RockDollars;
	public int SpeakerPrice;
	public int SpeakerUpgradePrice;
	public int BarPrice;
	public int BarUpgradePrice;
	public Text RockDollarText;
	public Text WinText;
	public Text StageHealthText;
	public Text GameOverText;
	public float x_coord_start;
	public float y_coord_start;
	public int level = 0;
	public int LastLevel;
	public bool GameOn = false;
	public CanvasGroup canvas;
	public CanvasGroup canvas2;
	public CanvasGroup canvas3;
	private StageScript stage;
	public AudioClip boo;
	public AudioClip solo;

	
	public GameObject mediumGroupie;
	public GameObject youngGroupie;
	public GameObject oldGroupie;
	public GameObject tankBoss;
	public GameObject caveTroll;
	public GameObject gummyBear;
	public static int SceneNumber = 1;

	AudioSource boosound;

	public class Level{
	public int levelNumber;
	public List<GroupOfGroupies> groupSequence;

	}

	public List<Level> LevelSequence;


	CaveTrollSound caveTrollSound;		
	GummyBearSound gummyBearSound;
		

	// Use this for initialization
	void Start () {

		caveTrollSound = GameObject.FindGameObjectWithTag ("TrollTag").GetComponent<CaveTrollSound>();
		gummyBearSound = GameObject.FindGameObjectWithTag ("GummyTag").GetComponent<GummyBearSound>();
		
		canvas.alpha = 0;
		canvas.interactable = false;
		canvas2.alpha = 0;
		canvas2.interactable = false;
		canvas3.alpha = 0.5f;
		canvas3.interactable = false;
		enemyCount = 0;
		EnemyStop = false;
		//SpeakerPrice = 50;
		//BarPrice = 60;
		//RockDollars = 100;
		stage = GameObject.FindGameObjectWithTag ("Stage").GetComponent<StageScript>();
		isMenu = false;

		GameOverText.text = "";
		WinText.text = "";
		RockDollarText.text = "Rock Dollars: " + RockDollars.ToString ();
		StageHealthText.text = "Band Moral: " + stage.StageHealth.ToString();

		LevelSequence = new List<Level> ();

		// First Scene
		//SceneNumber = 3;
		if (SceneNumber == 1) {

			Level One = new Level ();
			One.groupSequence = new List<GroupOfGroupies> ();
			One.levelNumber = 1;
			One.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 10, 0, 1f));
			LevelSequence.Add (One);
			
			Level Two = new Level ();
			Two.groupSequence = new List<GroupOfGroupies> ();
			Two.levelNumber = 2;
			Two.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 10, 0, 0.8f));
			Two.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 4, 0, 1f));
			LevelSequence.Add (Two);
			
			Level Three = new Level ();
			Three.groupSequence = new List<GroupOfGroupies> ();
			Three.levelNumber = 3;
			Three.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 5, 0, 0.4f));
			Three.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 10, 0, 0.4f));
			LevelSequence.Add (Three);
			
			Level Four = new Level ();
			Four.groupSequence = new List<GroupOfGroupies> ();
			Four.levelNumber = 4;
			Four.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 2, 0, 1f));
			Four.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 25, 0.5f, 0.4f));
			LevelSequence.Add (Four);
			
			Level Five = new Level ();
			Five.groupSequence = new List<GroupOfGroupies> ();
			Five.levelNumber = 5;
			Five.groupSequence.Add (new GroupOfGroupies ("TankBoss", 1, 0, 0));
			Five.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 6, 0.2f, 1.3f));
			Five.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 10, 0, 1.6f));
			LevelSequence.Add (Five);
			
			Level Six = new Level ();
			Six.groupSequence = new List<GroupOfGroupies> ();
			Six.levelNumber = 6;
			Six.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 10, 0, 1f));
			Six.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 5, 0, 0.3f));
			Six.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 13, 0, 0.5f));
			LevelSequence.Add (Six);
			
			Level Seven = new Level ();
			Seven.groupSequence = new List<GroupOfGroupies> ();
			Seven.levelNumber = 7;
			Seven.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 10, 0, 0.8f));
			Seven.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 10, 0, 0.5f));
			Seven.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 20, 0, 0.2f));
			LevelSequence.Add (Seven);
			
			Level Eight = new Level ();
			Eight.groupSequence = new List<GroupOfGroupies> ();
			Eight.levelNumber = 8;
			Eight.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 4, 0, 1));
			Eight.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 1, 0.4f, 0.1f));
			Eight.groupSequence.Add (new GroupOfGroupies ("GummyBear", 1, 0, 0));
			Eight.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 1, 0, 0));
			Eight.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 10, 0.4f, 0.2f));
			Eight.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 6, 0, 1));
			Eight.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 5, 0, 0.2f));
			Eight.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 10, 0.4f, 0.2f));
			LevelSequence.Add (Eight);
			
			Level Nine = new Level ();
			Nine.groupSequence = new List<GroupOfGroupies> ();
			Nine.levelNumber = 9;
			Nine.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 10, 0, 0.2f));
			Nine.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 5, 0, 0.4f));
			Nine.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 5, 0, 0.2f));
			Nine.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 10, 0, 0.5f));;
			Nine.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 5, 0f, 0.1f));
			Nine.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 20, 0.4f, 0.2f));

			LevelSequence.Add (Nine);

			Level Ten = new Level ();
			Ten.groupSequence = new List<GroupOfGroupies> ();
			Ten.levelNumber = 10;

			Ten.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 10, 0, 0.3f));
			Ten.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 15, 0, 0.3f));
			Ten.groupSequence.Add (new GroupOfGroupies ("CaveTroll", 1, 0, 0));
			Ten.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 5, 0, 0.1f));
			Ten.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 30, 0, 0.1f));

			LevelSequence.Add (Ten);
		} 
		// Second Scene
		else if (SceneNumber == 2) {
				/********************************************************/
				// ONLY GOES IN HERE IF GAME IS PLAYED FROM MAINMENU SCENE
				/********************************************************/
				Debug.Log ("SCENE TWO!");
				Level One = new Level ();
				One.groupSequence = new List<GroupOfGroupies> ();
				One.levelNumber = 1;
				One.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 15, 0, 1f));
				LevelSequence.Add (One);
				
				Level Two = new Level ();
				Two.groupSequence = new List<GroupOfGroupies> ();
				Two.levelNumber = 2;
				Two.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 10, 0, 0.8f));
				Two.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 10, 0, 1f));
				LevelSequence.Add (Two);
				
				Level Three = new Level ();
				Three.groupSequence = new List<GroupOfGroupies> ();
				Three.levelNumber = 3;
				Three.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 5, 0, 0.8f));
				Three.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 3, 0, 1));
				Three.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 5, 0, 0.6f));
				
				
				LevelSequence.Add (Three);
				
				Level Four = new Level ();
				Four.groupSequence = new List<GroupOfGroupies> ();
				Four.levelNumber = 4;
				Four.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 20, 0, 0.3f));
				Four.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 20, 0, 0.4f));
				Four.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 20, 0, 0.2f));
				LevelSequence.Add (Four);
				
				Level Five = new Level ();
				Five.groupSequence = new List<GroupOfGroupies> ();
				Five.levelNumber = 5;
				Five.groupSequence.Add (new GroupOfGroupies ("CaveTroll", 1, 1, 1.6f));
				Five.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 6, 0, 1));
				Five.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 20, 0, 0.5f));
				Five.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 20, 0, 0.4f));
				LevelSequence.Add (Five);
				
				Level Six = new Level ();
				Six.groupSequence = new List<GroupOfGroupies> ();
				Six.levelNumber = 6;
				Six.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 2, 0, 1.6f));
				Six.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 5, 0, 0.8f));
				Six.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 13, 0, 0.1f));
				Six.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 7, 0, 1.6f));
				Six.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 5, 0, 0.8f));
				Six.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 15, 0, 0.5f));
				Six.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 10, 0, 0.8f));
				
				LevelSequence.Add (Six);
				
				Level Seven = new Level ();
				Seven.groupSequence = new List<GroupOfGroupies> ();
				Seven.levelNumber = 7;
				Seven.groupSequence.Add (new GroupOfGroupies ("CaveTroll", 1, 1, 1.6f));
				Seven.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 4, 0, 0.5f));
				Seven.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 2, 0.4f, 0.6f));
				Seven.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 2, 0.4f, 0.3f));
				Seven.groupSequence.Add (new GroupOfGroupies ("TankBoss", 1, 0, 1.6f));
				Seven.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 2, 0.4f, 0.6f));
				Seven.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 20, 0, 0.1f));
				Seven.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 2, 0.4f, 0.6f));
				Seven.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 2, 0, 0.6f));
				Seven.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 20,0, 0.2f));
				Seven.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 2, 0.4f, 0.6f));
				Seven.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 6, 0, 0.8f));
				Seven.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 1, 0.1f, 0));
				Seven.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 1, 0.1f, 0));
				Seven.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 1, 0.1f, 0));
				Seven.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 1, 0.1f, 0));
				Seven.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 1, 0.1f, 0));
				Seven.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 1, 0.1f, 0));
				Seven.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 1, 0.1f, 0));
				LevelSequence.Add (Seven);
				
				Level Eight = new Level ();
				Eight.groupSequence = new List<GroupOfGroupies> ();
				Eight.levelNumber = 8;
				Eight.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 2, 1, 1));
				Eight.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 15, 0, 0.1f));
				Eight.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 10, 0.5f, 0.3f));
				Eight.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 20, 0.4f, 0.1f));
				Eight.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 20, 1, 0.3f));
				Eight.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 7, 0.4f, 0.2f));
				Eight.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 7, 1, 0.3f));
				Eight.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 7, 0.4f, 0.3f));
				
				LevelSequence.Add (Eight);
				
				Level Nine = new Level ();
				Nine.groupSequence = new List<GroupOfGroupies> ();
				Nine.levelNumber = 9;
				Nine.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 1, 1, 1));
				Nine.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 10, 0.4f, 0.1f));
				Nine.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 10, 0.5f, 0.2f));
				Nine.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 30, 0, 0.1f));
				Nine.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 5, 1, 1));
				Nine.groupSequence.Add (new GroupOfGroupies ("GummyBear", 1, 1, 1.6f));
				Nine.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 30, 0, 0.1f));
				Nine.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 30, 0.5f, 0.3f));
				Nine.groupSequence.Add (new GroupOfGroupies ("CaveTroll", 1, 1, 1.6f));
				Nine.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 30, 0, 0.1f));
				
				LevelSequence.Add (Nine);
				
				Level Ten = new Level ();
				Ten.groupSequence = new List<GroupOfGroupies> ();
				Ten.levelNumber = 10;
				Ten.groupSequence.Add (new GroupOfGroupies ("CaveTroll", 1, 1, 1.6f));
				Ten.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 40, 0.4f, 0.2f));
				Ten.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 40, 0, 0.1f));
				Ten.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 30, 0, 0.1f));
				Ten.groupSequence.Add (new GroupOfGroupies ("GummyBear", 1, 0, 1.6f));
				Ten.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 15, 0, 0.1f));
				Ten.groupSequence.Add (new GroupOfGroupies ("TankBoss", 1, 0, 0));
				Ten.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 10, 0, 0.5f));
				Ten.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 10, 0.4f, 0.2f));
				Ten.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 30, 0.5f, 0.4f));
				Ten.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 10, 0, 1));
				Ten.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 50, 0, 0.2f));
				Ten.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 70, 0.4f, 0.2f));
				Ten.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 9, 0.5f, 0.4f));
				
				
				LevelSequence.Add (Ten);


			/*
			Level Eleven = new Level ();
			Eleven.groupSequence = new List<GroupOfGroupies> ();
			Eleven.levelNumber = 11;
			Eleven.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 30, 0, 0.9f));
			Eleven.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 30, 0, 0.1f));
			Eleven.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 10, 0, 0.9f));
			Eleven.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 15, 0, 0.3f));
			Eleven.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 23, 0, 0.4f));
			Eleven.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 8, 0, 0.1f));
			Eleven.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 10, 0, 0.4f));
			Eleven.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 3, 0, 0.1f));
			Eleven.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 6, 0, 0.8f));
			Eleven.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 15, 0, 0.1f));
			Eleven.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 10, 0, 1.6f));
			Eleven.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 3, 0, 0.1f));
			Eleven.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 8, 0, 1.6f));
			
			LevelSequence.Add (Eleven);


			Level Twelve = new Level ();
			Twelve.groupSequence = new List<GroupOfGroupies> ();
			Twelve.levelNumber = 12;
			Twelve.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 100, 0, 0.9f));
			Twelve.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 50, 0, 0.9f));
			Twelve.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 60, 0, 0.1f));
			Twelve.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 13, 0, 0.9f));
			Twelve.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 15, 0, 0.3f));
			Twelve.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 23, 0, 1.6f));
			Twelve.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 60, 0, 0.1f));
			Twelve.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 10, 0, 0.4f));
			Twelve.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 3, 0, 0.1f));
			Twelve.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 6, 0, 0.8f));
			Twelve.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 15, 0, 0.1f));
			Twelve.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 10, 0, 1.6f));
			Twelve.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 3, 0, 0.1f));
			Twelve.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 8, 0, 1.6f));
			
			LevelSequence.Add (Twelve);


			Level Thirteen = new Level ();
			Thirteen.groupSequence = new List<GroupOfGroupies> ();
			Thirteen.levelNumber = 13;
			Thirteen.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 30, 0, 0.9f));
			LevelSequence.Add (Thirteen);


			Level Fourteen = new Level ();
			Fourteen.groupSequence = new List<GroupOfGroupies> ();
			Fourteen.levelNumber = 14;
			LevelSequence.Add (Fourteen);


			Level Fifteen = new Level ();
			Fifteen.groupSequence = new List<GroupOfGroupies> ();
			Fifteen.levelNumber = 15;
			Fifteen.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 30, 0, 0.9f));
			
			LevelSequence.Add (Fifteen);
			*/
		} 
		// Final Scene
		else {

			Level One = new Level ();
			One.groupSequence = new List<GroupOfGroupies> ();
			One.levelNumber = 1;
			One.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 10, 0, 1f));
			LevelSequence.Add (One);
			
			Level Two = new Level ();
			Two.groupSequence = new List<GroupOfGroupies> ();
			Two.levelNumber = 2;
			Two.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 10, 0, 0.8f));
			Two.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 4, 0, 1f));
			LevelSequence.Add (Two);
			
			Level Three = new Level ();
			Three.groupSequence = new List<GroupOfGroupies> ();
			Three.levelNumber = 3;
			Three.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 5, 0, 0.6f));
			Three.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 10, 0, 0.8f));
			LevelSequence.Add (Three);
			
			Level Four = new Level ();
			Four.groupSequence = new List<GroupOfGroupies> ();
			Four.levelNumber = 4;
			Four.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 2, 0, 1f));
			Four.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 22, 0.5f, 0.35f));
			LevelSequence.Add (Four);
			
			Level Five = new Level ();
			Five.groupSequence = new List<GroupOfGroupies> ();
			Five.levelNumber = 5;
			Five.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 6, 0, 0.9f));
			Five.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 10, 0, 0.9f));
			Five.groupSequence.Add (new GroupOfGroupies ("TankBoss", 1, 0, 0));
			LevelSequence.Add (Five);
			
			Level Six = new Level ();
			Six.groupSequence = new List<GroupOfGroupies> ();
			Six.levelNumber = 6;
			Six.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 10, 0, 1.3f));
			Six.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 5, 0, 0.3f));
			Six.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 13, 0, 0.5f));
			LevelSequence.Add (Six);
			
			Level Seven = new Level ();
			Seven.groupSequence = new List<GroupOfGroupies> ();
			Seven.levelNumber = 7;
			Seven.groupSequence.Add (new GroupOfGroupies ("GummyBear", 1, 0, 0));
			Seven.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 4, 0, 1.3f));
			Seven.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 1, 0.4f, 0));
			Seven.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 1, 0.4f, 0));
			Seven.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 1, 0.4f, 0));
			Seven.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 1, 0.4f, 0));
			Seven.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 1, 0.4f, 0));
			Seven.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 1, 0.4f, 0));
			Seven.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 1, 0.4f, 0));
			Seven.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 1, 0.4f, 0));
			Seven.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 1, 0.4f, 0));
			Seven.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 1, 0.4f, 0));
			Seven.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 1, 0.4f, 0));
			Seven.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 1, 0.4f, 0));
			Seven.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 1, 0.4f, 0));
			Seven.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 4, 0, 1.3f));
			Seven.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 1, 0.4f, 0));
			Seven.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 1, 0.4f, 0));
			Seven.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 1, 0.4f, 0));
			Seven.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 1, 0.4f, 0));
			Seven.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 1, 0.4f, 0));
			Seven.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 1, 0.4f, 0));
			Seven.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 1, 0.4f, 0));
			Seven.groupSequence.Add (new GroupOfGroupies ("TankBoss", 1, 0, 0));
			LevelSequence.Add (Seven);
			
			Level Eight = new Level ();
			Eight.groupSequence = new List<GroupOfGroupies> ();
			Eight.levelNumber = 8;
			Eight.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 1, 1, 0.6f));
			Eight.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 1, 0.4f, 0));
			Eight.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 1, 1, 0.6f));
			Eight.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 1, 0.4f, 0));
			Eight.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 1, 1, 1));
			Eight.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 1, 0.4f, 0));
			Eight.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 1, 1, 1));
			Eight.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 1, 0.4f, 0));
			Eight.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 1, 1, 1));
			Eight.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 1, 0.4f, 0));
			Eight.groupSequence.Add (new GroupOfGroupies ("GummyBear", 1, 0, 0));
			Eight.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 1, 1, 1));
			Eight.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 1, 0.4f, 0));
			Eight.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 1, 0.4f, 0));
			Eight.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 1, 0.4f, 0));
			Eight.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 1, 0.4f, 0));
			Eight.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 1, 0.4f, 0));
			Eight.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 1, 0.4f, 0));
			Eight.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 5, 1, 1));
			Eight.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 10, 0.4f, 0.2f));
			LevelSequence.Add (Eight);
			
			Level Nine = new Level ();
			Nine.groupSequence = new List<GroupOfGroupies> ();
			Nine.levelNumber = 9;
			Nine.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 1, 1, 1));
			Nine.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 1, 0.4f, 0));
			Nine.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 1, 0.5f, 0));
			Nine.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 1, 1, 1));
			Nine.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 1, 0.4f, 0));
			Nine.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 1, 0.5f, 0));
			Nine.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 1, 1, 1));
			Nine.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 1, 0.4f, 0));
			Nine.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 1, 0.5f, 0));
			Nine.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 1, 1, 1));
			Nine.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 1, 0.4f, 0));
			Nine.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 1, 0.5f, 0));
			Nine.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 1, 1, 1));
			Nine.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 1, 0.4f, 0));
			Nine.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 1, 0.5f, 0));
			Nine.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 1, 1, 1));
			Nine.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 1, 0.4f, 0));
			Nine.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 1, 0.5f, 0));
			Nine.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 20, 0.4f, 0.2f));
			Nine.groupSequence.Add (new GroupOfGroupies ("CaveTroll", 2, 0, 0));
			Nine.groupSequence.Add (new GroupOfGroupies ("TankBoss", 2, 0.5f, 0));
			
			
			LevelSequence.Add (Nine);
			
			Level Ten = new Level ();
			Ten.groupSequence = new List<GroupOfGroupies> ();
			Ten.levelNumber = 10;
			Ten.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 15, 0, 0.1f));
			Ten.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 10, 0, 0.3f));
			Ten.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 15, 0, 1f));
			Ten.groupSequence.Add (new GroupOfGroupies ("TankBoss", 1, 0, 0));
			Ten.groupSequence.Add (new GroupOfGroupies ("CaveTroll", 1, 0, 1));
			Ten.groupSequence.Add (new GroupOfGroupies ("GummyBear", 4, 1, 1));
			Ten.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 2, 1, 1));
			Ten.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 3, 0.4f, 0.2f));
			Ten.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 2, 0.5f, 0.4f));
			Ten.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 2, 1, 1));
			Ten.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 3, 0.4f, 0.2f));
			Ten.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 2, 0.5f, 0.4f));
			Ten.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 2, 1, 1));
			Ten.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 3, 0.4f, 0.2f));
			Ten.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 2, 0.5f, 0.4f));
			Ten.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 2, 1, 1));
			Ten.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 3, 0.4f, 0.2f));
			Ten.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 2, 0.5f, 0.4f));
			Ten.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 2, 1, 1));
			Ten.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 3, 0.4f, 0.2f));
			Ten.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 2, 0.5f, 0.4f));
			Ten.groupSequence.Add (new GroupOfGroupies ("OldGroupie", 2, 1, 1));
			Ten.groupSequence.Add (new GroupOfGroupies ("YoungGroupie", 3, 0.4f, 0.2f));
			Ten.groupSequence.Add (new GroupOfGroupies ("MediumGroupie", 2, 0.5f, 0.4f));
			
			LevelSequence.Add (Ten);

		}



	}
	// Update is called once per frame
	void Update () {
		WinLevel ();
	}
	
	public IEnumerator RunLevel(Level currentLevel)
	{
		canvas3.alpha = 1;
		canvas3.interactable = true;
		float z = -1f;

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
				else if(group.typeOfGroupie == "OldGroupie"){
					enemy =  oldGroupie;
				}
				else if(group.typeOfGroupie == "TankBoss"){
					enemy = tankBoss;
				}
				else if(group.typeOfGroupie == "CaveTroll"){
					enemy = caveTroll;
					caveTrollSound.RandomCaveClip();

				}
				else{
					enemy = gummyBear;
					gummyBearSound.RandomGummyClip();
				}
				if(SceneNumber == 3) {
					if(level == 6) i++;
					if(i % 2 == 0){
						Instantiate (enemy, new Vector3 (x_coord_start+1f, y_coord_start, z), Quaternion.identity);
					} else {
						Instantiate (enemy, new Vector3 (x_coord_start, y_coord_start, z), Quaternion.identity);
					}
					if(level == 6) i--;
				} else {
					Instantiate (enemy, new Vector3 (x_coord_start, y_coord_start, z), Quaternion.identity);
				}
				enemyCount++;
				Debug.Log ("increase" + enemyCount);
				yield return new WaitForSeconds (group.separationTime);
			}
		}
		level++;
		GameOn = false;
		//IncreaseRockDollars (5);
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

	public void FreezeEnemies(){
		StartCoroutine (StopEnemy());
	}

	public IEnumerator StopEnemy(){
		EnemyStop = true;
		canvas3.alpha = 0.5f;
		canvas3.interactable = false;
		GetComponent<AudioSource> ().PlayOneShot (solo);
		yield return new WaitForSeconds (3);
		EnemyStop = false;
	}

	public void DecreaseEnemyCount(){
		enemyCount--;
		Debug.Log ("Decrease" + enemyCount);
	}

	public void LoadNextLevel(){
		SceneNumber++;
		Debug.Log ("SceneNumber" + SceneNumber);
		Application.LoadLevel (SceneNumber);
	}

	public void RestartLevel(){
		Application.LoadLevel(Application.loadedLevel);
	}
	public void BackToMainMenu(){
		Application.LoadLevel(0);
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
