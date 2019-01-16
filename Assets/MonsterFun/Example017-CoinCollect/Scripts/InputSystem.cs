using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour {

        public enum ControlTypes  { ButtonAction, AxisAction };
        
        public enum ActionHandlers { MoveForward, TurnSideway };
        
        enum DeviceSources { UnityInputHorizontal, UnityInputVertical, UnityInputMouseX, UnityInputMouseY, ViveControllerTrigger };
        
        class ControlMappingElement
        {
          public ControlTypes controlType;
          public ActionHandlers action;
          public List<DeviceSources> devices;
          public List<System.Action <float>> eventHandlers;
          
          public ControlMappingElement (ControlTypes c, ActionHandlers a, List<DeviceSources> l)
          {
            action = a;
            controlType = c;
            devices = l;
            eventHandlers = new List<System.Action <float>> ();
          }
        };
        
        private ControlMappingElement [] controlMap = new ControlMappingElement [] {
          new ControlMappingElement (ControlTypes.AxisAction, ActionHandlers.MoveForward, new List<DeviceSources> { DeviceSources.UnityInputVertical, DeviceSources.UnityInputMouseY }),
          new ControlMappingElement (ControlTypes.AxisAction, ActionHandlers.TurnSideway, new List<DeviceSources> { DeviceSources.UnityInputHorizontal, DeviceSources.UnityInputMouseX }),
        };
        
        public void registerForInput (ControlTypes c, ActionHandlers a, System.Action <float> eventHandler)
        {
	  foreach (ControlMappingElement cme in controlMap)
	  {
	    if ((cme.controlType == c) && (cme.action == a))
	    {
	      cme.eventHandlers.Add (eventHandler);
	    }
	  }
        }
        
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
          pollUnityInput ();
	}
	
	// Check the unity input system, and map these to various device inputs.
	void pollUnityInput ()
	{
          float h = Input.GetAxis ("Horizontal");
          registerInput (DeviceSources.UnityInputHorizontal, h);
          float v = Input.GetAxis ("Vertical");
          registerInput (DeviceSources.UnityInputVertical, v);
          float mx = Input.GetAxis ("Mouse X");
          registerInput (DeviceSources.UnityInputMouseX, mx);
          float my = Input.GetAxis ("Mouse Y");
          registerInput (DeviceSources.UnityInputMouseY, my);
	}
	
	void registerInput (DeviceSources source, float value)
	{
	  foreach (ControlMappingElement cme in controlMap)
	  {
	    foreach (DeviceSources ds in cme.devices)
	    {
	      if (ds == source)
	      {
	        foreach (System.Action <float> ev in cme.eventHandlers)
	        {
	          ev (value);
	        }
	      }
	    }
	  }
	}
	
}
