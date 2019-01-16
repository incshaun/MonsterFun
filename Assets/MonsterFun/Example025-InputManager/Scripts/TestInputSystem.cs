using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInputSystem : MonoBehaviour {

    public SampleInputSystem inputSystem;

	// Use this for initialization
	void Start () {
		inputSystem.registerForInput (SampleInputSystem.ControlTypes.AxisAction, SampleInputSystem.ActionHandlers.MoveForward, forwardEventHandler);
		inputSystem.registerForInput (SampleInputSystem.ControlTypes.AxisAction, SampleInputSystem.ActionHandlers.TurnSideway, turnEventHandler);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void forwardEventHandler (float v)
	{
		if (v != 0.0f) {
			print ("Forward event: " + v);
		}
	}

	void turnEventHandler (float v)
	{
		if (v != 0.0f) {
			print ("Turn event: " + v);
		}
	}
}
