using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftByVector : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.gameObject.transform.position = 
		  this.gameObject.transform.position + new Vector3 (1, 2, 3);
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
