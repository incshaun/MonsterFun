using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinSaucer : MonoBehaviour {

	public float rotationSpeed = 20.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.localRotation *= Quaternion.AngleAxis (rotationSpeed * Time.deltaTime, new Vector3 (0, 1, 0));	
	}
}
