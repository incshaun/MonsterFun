using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate (0.0f, 1.0f, 0.0f);
		
		GameObject horse = GameObject.FindWithTag ("Horse");
		if (horse != null)
		{
		  horse.tag = "Untagged";
		  horse.gameObject.transform.parent = this.gameObject.transform;
		}
	}
}
