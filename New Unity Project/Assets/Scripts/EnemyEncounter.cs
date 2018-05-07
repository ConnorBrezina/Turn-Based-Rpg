using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
public class EnemyEncounter : MonoBehaviour {

	public bool m_fightAble = false;
	public string Words;
	public GameObject SpeechBubTextCan;
	public Text SpeechBubText;
	public GameObject SpeechBub;
	public int m_enemyCount;
	public int[] m_Abilities;
	private bool fightDis = false;
	public int EnemyIdNum;
	private static GameObject m_Player;

	void Start () {
		m_Player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.fightable [EnemyIdNum] == true) 
		{
			m_fightAble = true;
		}
		if (GameManager.fightable [EnemyIdNum] == false) 
		{
			m_fightAble = false;
		}
		if (fightDis == true && m_fightAble == true) 
		{
			GameManager.EnemyDefeated (EnemyIdNum);
			m_Player.GetComponent <Movement>().enabled = false;
			m_Player.GetComponent <Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
			StartCoroutine (PreFight ());
		}
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		Debug.Log ("entered");
		fightDis = true;
	}
	void OnTriggerExit2D(Collider2D collider)
	{
		Debug.Log ("exited");
		fightDis = false;
	}

	public static void EndBattle()
	{
		Debug.Log ("ENDBATTLE");
		m_Player.SetActive(true);
		m_Player.GetComponent <Movement>().enabled = true;
		m_Player.GetComponent <Rigidbody2D> ().constraints =  RigidbodyConstraints2D.None;
		m_Player.GetComponent <Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
	}

	IEnumerator PreFight()
	{
		GameManager.currentFight = EnemyIdNum;
		Debug.Log (EnemyIdNum);
		SpeechBubTextCan.SetActive(true);
		SpeechBub.SetActive(true);
		SpeechBubText.text = Words;
		yield return new WaitForSeconds (4);
		m_Player.SetActive(false);
		SpeechBubTextCan.SetActive(false);
		SpeechBub.SetActive(false);
		SceneManager.LoadScene ("BattleScene",LoadSceneMode.Additive);
		SceneManager.SetActiveScene (SceneManager.GetSceneByName("BattleScene"));
	}
}
