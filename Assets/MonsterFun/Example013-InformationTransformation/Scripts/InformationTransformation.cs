using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationTransformation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
//	  float radius = 3.0f;
//	  float circlex = radius * Mathf.Sin (Time.time);
//	  float circley = radius * Mathf.Cos (Time.time);
//	  this.gameObject.transform.position = new Vector3 (circlex, circley, 0);
	  
  	  this.gameObject.transform.position = new Vector3 (3.0f * Mathf.Sin (Time.time), 3.0f * Mathf.Cos (Time.time), 0);

	}
}
