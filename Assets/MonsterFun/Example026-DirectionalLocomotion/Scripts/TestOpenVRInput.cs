using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class TestOpenVRInput : MonoBehaviour {

	// Suggest setting this to gesture: GrabPinch
	public SteamVR_Action_Boolean trigger;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float v1 = Input.GetAxis ("LeftTrigger") + (trigger.GetState (SteamVR_Input_Sources.LeftHand) ? 1 : 0);	
		float v2 = Input.GetAxis ("RightTrigger") + (trigger.GetState (SteamVR_Input_Sources.RightHand) ? 1 : 0);
		print ("Triggers: " + v1 + " " + v2);
	}
}
