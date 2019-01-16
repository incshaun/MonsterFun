using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteerObject : MonoBehaviour {

	public float speed = 0.1f;
	public float turnspeed = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		this.transform.position += speed * Time.deltaTime * v * this.transform.forward;
		this.transform.rotation *= Quaternion.AngleAxis (turnspeed * Time.deltaTime * h, this.transform.up);
	}
}
