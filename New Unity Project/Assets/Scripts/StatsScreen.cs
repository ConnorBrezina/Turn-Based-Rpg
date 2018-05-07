using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsScreen : MonoBehaviour {

	public PlayerStats Stats;
	public Button[] UpgradeButtons;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerStats.m_LevelsToGain > 0) 
		{
			UpgradeButtons[0].gameObject.SetActive(true);
			UpgradeButtons[1].gameObject.SetActive(true);
			UpgradeButtons[2].gameObject.SetActive(true);
			UpgradeButtons[3].gameObject.SetActive(true);
			UpgradeButtons[4].gameObject.SetActive(true);
		}
		else
		{
			UpgradeButtons[1].gameObject.SetActive(false);
			UpgradeButtons[2].gameObject.SetActive(false);
			UpgradeButtons[3].gameObject.SetActive(false);
			UpgradeButtons[4].gameObject.SetActive(false);
			UpgradeButtons[0].gameObject.SetActive(false);
		}
	}

	public void StrUp()
	{
		PlayerStats.Strength++;
		PlayerStats.m_LevelsToGain--;
		PlayerStats.CurrentHealth = PlayerStats.MainHealth;
	}
	public void IntUp()
	{
		PlayerStats.Intelligence++;
		PlayerStats.m_LevelsToGain--;
		PlayerStats.CurrentHealth = PlayerStats.MainHealth;
	}
	public void AgilUp()
	{
		PlayerStats.Agility++;
		PlayerStats.m_LevelsToGain--;
		PlayerStats.CurrentHealth = PlayerStats.MainHealth;
	}
	public void ConUp()
	{
		PlayerStats.Constitution++;
		PlayerStats.m_LevelsToGain--;
		PlayerStats.CurrentHealth = PlayerStats.MainHealth;
	}
	public void WisUp()
	{
		PlayerStats.Wisdom++;
		PlayerStats.m_LevelsToGain--;
		PlayerStats.CurrentHealth = PlayerStats.MainHealth;
	}

}
