using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GavelBehaviour : MonoBehaviour {

	// Assume this script is assigned to the gavel.
	public float frequency = 5.0f;

	void Start () {

	}

	void Update () {
		transform.position  += new Vector3 (0, 1.0f + 0.5f * Mathf.Sin (frequency * Time.fixedTime), 0);	
	}

	void OnTriggerEnter (Collider other)
	{
		Debug.Log ("Tap");
		this.GetComponent <AudioSource> ().Play ();
	}
}
