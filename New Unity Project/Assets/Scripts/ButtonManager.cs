using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

	private Canvas m_Inventory;
	public int inv = 1;
	private bool InvOpen = false;
	public Image LevelScreen;
	private bool LevelOpen = false;
	public Button LevelButton;
	public PlayerStats Stats;
	public Canvas Pause;
	public GameObject[] Destroyables;
	public int x = 4;

	void Start()
	{
		GameObject tempObject = GameObject.Find("InvCanvas");
		m_Inventory = tempObject.GetComponent<Canvas> ();
		m_Inventory.gameObject.SetActive(false);
	}
	public void NewGame()
	{
		SceneManager.LoadScene ("Level1", LoadSceneMode.Single);
	}
	public void QuitGame()
	{
		Application.Quit ();
	}
	public void Continue()
	{
		SaveLoad.Load();
	}
	public void Continue2()
	{
		Pause.gameObject.SetActive(false);
	}
	public void Save()
	{
		SaveLoad.Save ();
	}
	public void MainMenu()
	{
		SceneManager.LoadScene ("Main Menu", LoadSceneMode.Single);
		for(int i = 0; i < x; i++)
		{
			Destroy (Destroyables [i]);
		}
	}
	public void OpenInv()
	{
		if (InvOpen == false) {
			m_Inventory.gameObject.SetActive(true);
			Debug.Log ("open");
			InvOpen = true;

		} 
		else 
		{
			m_Inventory.gameObject.SetActive(false);
			InvOpen = false;
			Debug.Log ("closed");
		}

	}
	public void LevelUp()
	{
		if (LevelOpen == false) {
			LevelScreen.gameObject.SetActive (true);
			Debug.Log ("open");
			LevelOpen = true;
			PlayerStats.Opened = true;
		}
	}
	public void CloseButton()
	{
		LevelScreen.gameObject.SetActive(false);
		PlayerStats.Opened = false;
		LevelOpen = false;
	}
}
