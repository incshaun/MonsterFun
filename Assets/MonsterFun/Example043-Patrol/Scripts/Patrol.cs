using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {

	public Transform startPoint;
	public Transform endPoint;

	void Update () {
		float time = Time.time;
		float frequency = 2.2f;
		float t = 0.5f + 0.5f * Mathf.Sin (frequency * time);

		transform.position = (1.0f - t) * startPoint.position + (t) * endPoint.position;
		transform.forward = (-1.0f * startPoint.position + 1.0f * endPoint.position) * Mathf.Cos (frequency * time);
	}
}
