using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour {

	private RectTransform m_invRect;

	private float m_inventoryWidth, m_inventoryHeight;

	public int m_invSlots;

	public int m_invRows;

	public float m_slotPaddingLeft, m_slotPaddingTop;

	public float m_slotSize;

	public GameObject m_slotPrefab;

	private List<GameObject> m_allSlots;

	// Use this for initialization
	void Awake () {

	}


	void Start () {
		CreateLayout ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void CreateLayout()
	{
		m_allSlots = new List<GameObject> ();

		m_inventoryWidth = (m_invSlots / m_invRows) * (m_slotSize + m_slotPaddingLeft) + m_slotPaddingLeft;
		m_inventoryHeight = m_invRows * (m_slotSize + m_slotPaddingTop) + m_slotPaddingTop;

		m_invRect = GetComponent<RectTransform> ();

		m_invRect.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, m_inventoryWidth);
		m_invRect.SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, m_inventoryHeight);

		int columns = m_invSlots / m_invRows;

		for (int y = 0; y < m_invRows; y++)
		{
			for (int x = 0; x < columns; x++)
			{
				GameObject newSlot = (GameObject)Instantiate (m_slotPrefab);

				RectTransform slotRect = newSlot.GetComponent<RectTransform>();

				newSlot.name = "Slot";

				newSlot.transform.SetParent (this.transform.parent);

				slotRect.localPosition = m_invRect.localPosition + new Vector3 (m_slotPaddingLeft * (x + 1) + (m_slotSize * x), -m_slotPaddingTop * (y + 1) - (m_slotSize * y));

				slotRect.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, m_slotSize);
				slotRect.SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, m_slotSize);

				m_allSlots.Add (newSlot);
			}
		}
	}
}
