using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTargets : MonoBehaviour {

	public GameObject LFootTarget;
	public GameObject RFootTarget;
	public GameObject LHandTarget;
	public GameObject RHandTarget;
	public GameObject HeadTarget;

	public float speed = 1.0f;
	public float stretch = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		LFootTarget.transform.position = new Vector3 (0.5f, 0, stretch * Mathf.Sin (speed * Time.time));
		RFootTarget.transform.position = new Vector3 (-0.5f, 0, -stretch * Mathf.Sin (speed * Time.time));
		LHandTarget.transform.position = new Vector3 (1.5f, 1.0f + stretch * Mathf.Cos (speed * Time.time), stretch * Mathf.Sin (speed * Time.time));
		RHandTarget.transform.position = new Vector3 (-1.5f, 1.0f + stretch * Mathf.Sin (speed * Time.time), stretch * Mathf.Cos (speed * Time.time));
		HeadTarget.transform.position = new Vector3 (stretch * Mathf.Sin (speed * Time.time), 1.5f + 0.5f * stretch * Mathf.Sin (speed * Time.time), stretch * Mathf.Cos (speed * Time.time));
	}
}
