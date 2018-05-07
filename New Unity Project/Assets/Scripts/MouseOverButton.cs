using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseOverButton : MonoBehaviour//, ISelectHandler, IPointerEnterHandler
{

	public Text HelpStr;
	public Text HelpInt;
	public Text HelpAgil;
	public Text HelpCon;
	public Text HelpWis;


	public void ShowStr()
	{
		HelpStr.gameObject.SetActive(true);
	}
	public void HideStr()
	{
		HelpStr.gameObject.SetActive(false);
	}
	public void ShowInt()
	{
		HelpInt.gameObject.SetActive(true);
	}
	public void HideInt()
	{
		HelpInt.gameObject.SetActive(false);
	}
	public void ShowAgil()
	{
		HelpAgil.gameObject.SetActive(true);
	}
	public void HideAgil()
	{
		HelpAgil.gameObject.SetActive(false);
	}
	public void ShowCon()
	{
		HelpCon.gameObject.SetActive(true);
	}
	public void HideCon()
	{
		HelpCon.gameObject.SetActive(false);
	}
	public void ShowWis()
	{
		HelpWis.gameObject.SetActive(true);
	}
	public void HideWis()
	{
		HelpWis.gameObject.SetActive(false);
	}

}