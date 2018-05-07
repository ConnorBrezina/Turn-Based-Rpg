using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

	public FightManager dmg;
	private int Thisfight;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Thisfight = GameManager.currentFight;
	}

	public void ChooseMove()
	{
		int MoveChoi = Random.Range (1, 4);
		if(Thisfight == 0 || Thisfight == 2){
			if (MoveChoi == 1) 
			{
				dmg.DMG (20 + (5* Thisfight), 2,0);
			}
			if(MoveChoi == 2)
			{
				dmg.DMG (35+(5* Thisfight), 2,0);
			}
			if(MoveChoi ==3)
			{
				dmg.DMG (15+(10* Thisfight), 2,0);
			}
		}
		if(Thisfight == 1 || Thisfight == 3){
			if (MoveChoi == 1) 
			{
				dmg.DMG (5 + (10* Thisfight), 2,0);
			}
			if(MoveChoi == 2)
			{
				dmg.DMG (15+(5* Thisfight), 2,0);
			}
			if(MoveChoi ==3)
			{
				dmg.DMG (0, 2,10+(10* Thisfight));
			}
		}
	}
}
