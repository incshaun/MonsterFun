using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaucerMaker : MonoBehaviour {

	public GameObject saucerPrefab;

	// Use this for initialization
	void Start () {
	
		Instantiate (saucerPrefab, new Vector3 (-4, 4, 6), Quaternion.identity);
		Instantiate (saucerPrefab, new Vector3 (7, 5, 7), Quaternion.identity);
		Instantiate (saucerPrefab, new Vector3 (2, 3, 2), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
