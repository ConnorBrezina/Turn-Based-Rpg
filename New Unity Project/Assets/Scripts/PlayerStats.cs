using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	static private int m_playerLevel = 1;
	static public int m_LevelsToGain = 0;
	static public bool Opened = false;
	static public int m_playerExp = 0;
	static public int m_nextLevelExp = 500;
	static public int Intelligence = 10;
	static public int Strength = 10;
	static public int Constitution = 10;
	static public int Agility = 10;
	static public int Wisdom = 10;
	private int m_varX = 1;
	public Text m_levelText;
	public Text m_expText;
	public static int Moneys=0;
	public Text Money;
	public Button Levelup;
	static public int MainHealth;
	static public int CurrentHealth;

	void Awake()
	{
		DontDestroyOnLoad (transform.gameObject);
		if (FindObjectsOfType (GetType ()).Length > 1) {
			Destroy (gameObject);
		}
	}
	// Use this for initialization
	void Start () {
		Moneys=0;
		m_playerLevel = 1;
		m_LevelsToGain = 0;
		Opened = false;
		m_playerExp = 0;
		m_nextLevelExp = 500;
		Intelligence = 10;
		Strength = 10;
		Constitution = 10;
		Agility = 10;
		Wisdom = 10;
		MainHealth = 100;
		CurrentHealth = MainHealth;
		Debug.Log ("HPupdated");
	}
	
	// Update is called once per frame
	void Update () {
		MainHealth = (100 + (25 * (Constitution - 10)) + (5 * (Strength - 10)));
		m_levelText.text = "" + m_playerLevel;
		m_expText.text = "" + m_playerExp + " / " + m_nextLevelExp;
		DontDestroyOnLoad (this.transform.gameObject);
		Money.text = "Money: " + Moneys + "$";
		if (m_LevelsToGain > 0 && Opened == false) 
		{
			Levelup.gameObject.SetActive(true);
		}
		else
			Levelup.gameObject.SetActive(false);
	}

	public void gainedExp (int Exp)
	{
		m_playerExp += Exp;
		if (m_playerExp >= m_nextLevelExp)
		{
			m_playerLevel++;
			m_playerExp -= m_nextLevelExp;
			m_nextLevelExp = (500 * m_varX) + (2* m_varX * 10)*(2* m_varX * 10);
			m_varX ++;
			m_LevelsToGain++;
		}
	}
}
