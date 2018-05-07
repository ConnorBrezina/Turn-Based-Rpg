using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityB : MonoBehaviour {

	private bool Allowed = true;
	public FightManager dmg;
	public PlayerStats Stats;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Allowed == true) 
		{
			
		}
	}

	void OnMouseDown()
	{
		if(Allowed == true)
		dmg.DMG (0, 1, (20+(5* (PlayerStats.Intelligence - 10))+(15 * (PlayerStats.Wisdom - 10))));
	}

	public void Allow()
	{
		Allowed = true;
	}
	public void DisAllow()
	{
		Allowed = false;
	}
}
