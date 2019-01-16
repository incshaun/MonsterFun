using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandSaucer : MonoBehaviour {

	// if using drop at constant speed option.
	public float dropSpeed = 1.0f;

	// if using the drop slower when getting closer to ground option.
	public float dropFactor = 0.1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y > 0) {
			transform.position -= new Vector3 (0, Time.deltaTime * dropSpeed, 0);
		}

		// decrease the height (y value) by proportion dropFactor. This saves having to
		// check when they get to the ground because they never actually get there.
		//transform.position -= new Vector3 (0, Time.deltaTime * dropFactor * transform.position.y, 0);
	}
}
