using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class MoveInDirectionOfTrackedObject : MonoBehaviour {

	// Suggest setting this to gesture: GrabPinch
	public SteamVR_Action_Boolean trigger;

	public GameObject steeringObject;

	private float speed = 3.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float v1 = Input.GetAxis ("LeftTrigger") + (trigger.GetState (SteamVR_Input_Sources.LeftHand) ? 1 : 0);	
		float v2 = Input.GetAxis ("RightTrigger") + (trigger.GetState (SteamVR_Input_Sources.RightHand) ? 1 : 0);
		if ((v1 > 0) || (v2 > 0)) {
			this.transform.position = this.transform.position + speed * steeringObject.transform.forward * Time.deltaTime;
		}
	}
}
