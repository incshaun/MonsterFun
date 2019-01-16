using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelGenerate : MonoBehaviour {

	public int numberOfAngels = 5;

	public float radius = 10.0f;

	public GameObject angelTemplate;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < numberOfAngels; i++) {
			Instantiate (angelTemplate, new Vector3 (Random.Range (-radius, radius), 0, Random.Range (-radius, radius)), Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
