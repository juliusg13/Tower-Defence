using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GroupOfGroupies {

	public string typeOfGroupie;
	public int howMany;
	public float DelayTime;
	public float separationTime;

	public GroupOfGroupies(string Type, int count, float delay, float Separation)
	{
		typeOfGroupie = Type;
		howMany = count;
		DelayTime = delay;
		separationTime = Separation;
	}


	
}
