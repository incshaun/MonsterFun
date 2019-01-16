using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Drop an object at regular intervals.
public class RegularRelease : MonoBehaviour {

	[Tooltip ("Prefab of object for dropping")]
	public GameObject dropObjectTemplate;

	[Tooltip ("Time intervals in seconds between dropping objects")]
	public float timeInterval = 2.0f;

	[Tooltip ("Position to drop the object from")]
	public Vector3 dropPosition = new Vector3 (0, 200, 0);

	// count time until next object ready for dropping.
	private float counter;

	// Use this for initialization
	void Start () {
		counter = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		counter += Time.deltaTime;

		if (counter > timeInterval) {
			// drop object, potentially with random offet.
			Instantiate (dropObjectTemplate, new Vector3 (0 * Random.Range (-0.01f, 0.01f),0,0) + dropPosition, Quaternion.identity);
			counter = 0.0f;
		}
	}
}
