using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FightManager : MonoBehaviour {

	private int Turn = 0;
	public int AllyHp1;
	public int EnemyHp1;
	public EnemyAI AI;
	public Text AllyHp1Text;
	public Text EnemyHp1Text;
	public AbilityA ability1;
	public AbilityB ability2;
	public PlayerStats exp;
	public int log = 0;
	private int Dodged;
	public static int CurrentFight;
	public SpriteRenderer spriteR;
	public Sprite[] sprites;
	public int Exp;
	public SpriteRenderer spriteM;
	public Sprite[] spritesMega;
	public ParticleSystem [] Attacks;
	public GameObject[] Holders;
	public Text[] DestroyTexts;
	private int x = 4;

	public Text Log;
	// Use this for initialization
	void Start () {
		for(int i = 0; i < x; i++)
		{
			//Attacks[i] = Holders[i].GetComponent<ParticleSystem>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		AllyHp1 = PlayerStats.CurrentHealth;
		CurrentFight = GameManager.currentFight;
		spriteR.sprite = sprites [CurrentFight];
		AllyHp1Text.text = "Hp: " + AllyHp1;
		EnemyHp1Text.text = "Hp: " + EnemyHp1;

		if (AllyHp1 <= 0) 
		{

		}
		if (EnemyHp1 <= 0) 
		{
			StartCoroutine (Endbattle ());
			Log.text = null;
			Log.text = "\n YOU WIN!";
		}
		if (CurrentFight != 0) 
		{
			Destroy (Holders[0]);
			Destroy (Holders[1]);
			Destroy (DestroyTexts[1]);
			Destroy (DestroyTexts[0]);
		}
	}

	public void DMG(int amount, int target, int Healed)
	{
		
		if (target == 1) 
		{
			if (log == 2) {
				Log.text = null;
				log = 0;
			}
			AllyHp1 += Healed;
			PlayerStats.CurrentHealth = AllyHp1;
			EnemyHp1 -= amount;
			DisAllowMove ();
			if (amount > 0) 
			{
				Log.text += "\n You did " + amount + " damage!";
				Attacks [1].Play();
			}
			if (Healed > 0) 
			{
				Log.text += "\n You Healed " + Healed + " health!";
				Attacks [0].Play();
			}
			spriteM.sprite = spritesMega [1];
			StartCoroutine (Wait1 ());
		}
		if (target == 2) 
		{
			Dodged = Random.Range (0, 100);
			if(Dodged <= (50 * (PlayerStats.Agility -10)))
			{
				amount = 0;
				Log.text += "\n You dodged the attack!!";
				log++;
			}
			EnemyHp1 += Healed;
			AllyHp1 -= amount;
			PlayerStats.CurrentHealth = AllyHp1;
			if (amount > 0) {
				Log.text += "\n Enemy did " + amount + " damage!";
				spriteM.sprite = spritesMega [2];
				Attacks [2].Play ();
			}
			if (Healed > 0) {
				Log.text += "\n Enemy Healed " + Healed + " health!";
				Attacks [3].Play ();
			}
			StartCoroutine (Wait2 ());
		}
	}
	void AllowMove()
	{
		ability1.Allow ();
		ability2.Allow ();
	}

	void DisAllowMove ()
	{
		ability1.DisAllow ();
		ability2.DisAllow ();
	}
	private IEnumerator Endbattle()
	{
		ability1.DisAllow ();
		ability2.DisAllow ();
		PlayerStats.CurrentHealth = AllyHp1;
		yield return new WaitForSeconds (2);
		exp.gainedExp (500 + (CurrentFight * 100));
		//SceneManager.LoadScene ("Test",LoadSceneMode.Additive);
		EnemyEncounter.EndBattle();
		SceneManager.UnloadSceneAsync("BattleScene");
	}
	private IEnumerator Wait1 ()
	{
		yield return new WaitForSeconds (3);
		spriteM.sprite = spritesMega [0];
		AI.ChooseMove ();
		Turn++;
		log++;
	}
	private IEnumerator Wait2 ()
	{
		yield return new WaitForSeconds (3);
		spriteM.sprite = spritesMega [0];
		AllowMove();
		Turn++;
	}
}
