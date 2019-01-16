using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyVectors : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.gameObject.transform.position = new Vector3 (1, 2, 3);
		this.gameObject.transform.localScale = new Vector3 (0.5f, 2.0f, 0.1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
