using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter (Collider other)
	{
	  //this.GetComponent <Rigidbody> ().velocity = new Vector3 (Random.Range (-2.3f, 2.3f), 3.1f, Random.Range (-2.3f, 2.3f));
	}
	
	void OnCollisionEnter (Collision collision)
	{
	  //this.GetComponent <Rigidbody> ().velocity += new Vector3 (Random.Range (-0.1f, -0.1f), 0, Random.Range (-0.1f, 0.1f));
	  //this.transform.localScale = 0.99f * this.transform.localScale;
	}
}
