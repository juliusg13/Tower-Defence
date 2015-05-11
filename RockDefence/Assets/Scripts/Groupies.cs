using UnityEngine;
using System.Collections;

public class Groupies : MonoBehaviour {

	public class TypeOfGroupie{

	public string name;
	public double speed;
	public double health;
	
		public TypeOfGroupie(string newName, double newSpeed, double newHealth)
		{
			name = newName;
			speed = newSpeed;
			health = newHealth;
		
		}
	}
	TypeOfGroupie YoungGroupie = new TypeOfGroupie ("YoungGroupie", 0.8, 2);
	TypeOfGroupie MediumGroupie = new TypeOfGroupie ("MediumGroupie", 0.4, 4);
	TypeOfGroupie OldGroupie = new TypeOfGroupie ("OldGroupie", 0.2, 12);


}
