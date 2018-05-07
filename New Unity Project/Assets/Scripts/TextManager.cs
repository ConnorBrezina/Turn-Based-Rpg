using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

	public Text GoodGuy;

	// Use this for initialization
	void Start () {
		GoodGuy.text = "Hey sorry about that old guy he likes to fight everyone in desperate hopes to finally win a battle :/";
		StartCoroutine (NextText1());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public IEnumerator NextText1()
	{
		yield return new WaitForSeconds (6);
		GoodGuy.text = "How about someone just helps you out for once? Heres 20$ moneys";
		StartCoroutine (NextText2());
	}
	public IEnumerator NextText2()
	{
		yield return new WaitForSeconds (4);
		GoodGuy.text = "Check your inventory in the top right to see how much moneys you have now!";
	}
}
