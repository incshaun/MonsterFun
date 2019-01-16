using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rot : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.localRotation *= Quaternion.AngleAxis (5.0f, Vector3.forward);
	}
}
