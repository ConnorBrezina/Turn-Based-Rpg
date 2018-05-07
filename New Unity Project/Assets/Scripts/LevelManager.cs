using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public string m_levelName;
	private bool m_levelEntrance = false;
	private GameObject Player;

	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
		if (m_levelEntrance == true)
		{
			SceneManager.LoadScene (m_levelName,LoadSceneMode.Single);
			if (Player.transform.position.y > 3.5) 
			{
				PlayerStats.Moneys += 20;
				Player.transform.position = new Vector2 (Player.transform.position.x, -4);
			}
			if (Player.transform.position.x > 7) 
			{
				Player.transform.position = new Vector2 ( -8, Player.transform.position.y);
			}
			if (Player.transform.position.y < -4) 
			{
				PlayerStats.Moneys += 20;
				Player.transform.position = new Vector2 (Player.transform.position.x, 3);
			}
		}
	}
	void OnTriggerEnter2D(Collider2D collider)
	{
		Debug.Log ("entered");
		m_levelEntrance = true;
	}
	void OnTriggerExit2D(Collider2D collider)
	{
		Debug.Log ("exited");
		m_levelEntrance = false;
	}
}
