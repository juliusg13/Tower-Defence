using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Controller : MonoBehaviour {
	public bool isMenu;
	public int RockDollars;
	public Text RockDollarText;

	// Use this for initialization
	void Start () {
		isMenu = false;
		RockDollars = 100;
		RockDollarText.text = "Rock Dollars: " + RockDollars.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
