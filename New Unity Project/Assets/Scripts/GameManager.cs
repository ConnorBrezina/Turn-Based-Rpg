using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static bool [] fightable;
	public int x;
	public static int currentFight;
	public Canvas Pause;


	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad (transform.gameObject);
		if (FindObjectsOfType (GetType ()).Length > 1) {
			Destroy (gameObject);
		}
		fightable = new bool[x];
	}
	void Start ()
	{
		for(int i = 0; i < x; i++)
		{
			fightable[i] = true;
		}
		currentFight = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.P))
		{
			Pause.gameObject.SetActive(true);
		}

	}

	public static void EnemyDefeated (int EnemyIDNumber)
	{
		fightable [EnemyIDNumber] = false;
	}
}
