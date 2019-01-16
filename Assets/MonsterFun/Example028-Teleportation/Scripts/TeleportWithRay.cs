using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class TeleportWithRay: MonoBehaviour {

	// Suggest setting this to gesture: GrabPinch
	public SteamVR_Action_Boolean trigger;

	// Suggest setting this to gesture: GrabGrip
	public SteamVR_Action_Boolean grip;

	public GameObject controller;

	public GameObject targetPrefab;

	private GameObject targetMarker;
	private Vector3 lastRayPoint;

	public GameObject avatar;

	// Use this for initialization
	void Start () {
		targetMarker = Instantiate (targetPrefab);
		targetMarker.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		    // distance to search along ray.
		float distance = 100.0f;

		float v1 = Input.GetAxis ("LeftTrigger") + (trigger.GetState (SteamVR_Input_Sources.LeftHand) ? 1 : 0);	
		float v2 = Input.GetAxis ("RightTrigger") + (trigger.GetState (SteamVR_Input_Sources.RightHand) ? 1 : 0);
		if ((v1 > 0) || (v2 > 0)) {
			RaycastHit hit;
			if (Physics.Raycast (new Ray (controller.transform.position, controller.transform.forward), out hit, distance)) {
				lastRayPoint = hit.point;
				targetMarker.transform.position = lastRayPoint;
				targetMarker.SetActive (true);
			}
		}

		float v3 = Input.GetAxis ("LeftGrip") + (grip.GetState (SteamVR_Input_Sources.LeftHand) ? 1 : 0);	
		float v4 = Input.GetAxis ("RightGrip") + (grip.GetState (SteamVR_Input_Sources.RightHand) ? 1 : 0);
		if ((v3 > 0) || (v4 > 0)) {
			avatar.transform.position = lastRayPoint + new Vector3 (0, 1, 0);
		}
	
	}
}
