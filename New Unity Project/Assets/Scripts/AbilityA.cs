using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityA : MonoBehaviour {

	private bool Allowed = true;
	public FightManager dmg;
	public PlayerStats Stats;
	// Use this for initialization
	void Start () {

		//Debug.Log (Stats.Moneys);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown()
	{
		if(Allowed == true)
		dmg.DMG ((30+(10* (PlayerStats.Intelligence - 10))+(5 * (PlayerStats.Wisdom - 10))), 1, 0);
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
