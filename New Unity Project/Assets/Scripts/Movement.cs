using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public Rigidbody2D rigB;
	public float movespeed = 1.0f;
	public bool facingRight = true;
	public Animator Run;
	//public Animator walking;
	// Use this for initialization

	void Start () {
		rigB = GetComponent<Rigidbody2D>();

	}
	void Awake () {
		DontDestroyOnLoad (transform.gameObject);
		if (FindObjectsOfType (GetType ()).Length > 1) {
			Destroy (gameObject);
		}
	}
	// Update is called once per frame
	void FixedUpdate () {
		Movementz ();
		if (facingRight == true) {
			this.transform.localScale = new Vector3 (0.5f, 0.5f, 0.0f);
		} else 
		{
			this.transform.localScale = new Vector3 (-0.5f, 0.5f, 0.0f);
		}

	}

	void Movementz() 
	{
		if (Input.GetKey (KeyCode.A)) 
		{
			rigB.velocity = (new Vector3(-movespeed, 0.0f, 0.0f));
			//walking.SetBool("Running",true);
			facingRight = false;
			Run.SetBool ("Running", true);
		}
		else if (Input.GetKey (KeyCode.W)) 
		{
			rigB.velocity = (new Vector3(0.0f, movespeed, 0.0f));
			//walking.SetBool("Running",true);
			Run.SetBool ("Running", true);
		}
		else if (Input.GetKey (KeyCode.S)) 
		{
			rigB.velocity = (new Vector3(0.0f, -movespeed, 0.0f));
			//walking.SetBool("Running",true);
			Run.SetBool ("Running", true);
		}
		else if (Input.GetKey (KeyCode.D)) 
		{
			rigB.velocity = (new Vector3(movespeed, 0.0f, 0.0f));
			//walking.SetBool("Running",true);
			facingRight = true;
			Run.SetBool ("Running", true);
		}
		else
			rigB.velocity = (new Vector3(0.0f, 0.0f, 0.0f));
		if (Input.GetKeyUp (KeyCode.D) || Input.GetKeyUp (KeyCode.A) || Input.GetKeyUp (KeyCode.W) || Input.GetKeyUp (KeyCode.S))
		{
			//walking.SetBool("Running",false);
			Run.SetBool ("Running", false);
		}
	}

}