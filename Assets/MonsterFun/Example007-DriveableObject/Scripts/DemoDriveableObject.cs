using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoDriveableObject : MonoBehaviour {

        public DemoInputSystem inputSystem;

        public float speed = 1.0f;
        public float turnspeed = 0.1f;
        
	// Use this for initialization
	void Start () {
		inputSystem.registerForInput (DemoInputSystem.ControlTypes.AxisAction, DemoInputSystem.ActionHandlers.MoveForward, forwardEventHandler);
		inputSystem.registerForInput (DemoInputSystem.ControlTypes.AxisAction, DemoInputSystem.ActionHandlers.TurnSideway, turnEventHandler);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void forwardEventHandler (float v)
	{
	  this.transform.position = this.transform.position + speed * v * this.transform.forward;
	}

	void turnEventHandler (float v)
	{
	  this.transform.rotation = this.transform.rotation * Quaternion.AngleAxis (turnspeed * v, this.transform.up);
	}
}
