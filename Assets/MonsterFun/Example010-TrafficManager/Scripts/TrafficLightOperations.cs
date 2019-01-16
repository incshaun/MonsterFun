using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightOperations : MonoBehaviour {

        public Material redMaterial;
        public Material greenMaterial;
        public Material yellowMaterial;
        public Material offMaterial;
        
        public GameObject redLight;
        public GameObject greenLight;
        public GameObject yellowLight;
        
	// Use this for initialization
	void Start () {
          setColour ("red");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void setColour (string colour)
	{
	  // first switch all lights off
	  redLight.GetComponent<MeshRenderer> ().material = offMaterial;
	  greenLight.GetComponent<MeshRenderer> ().material = offMaterial;
	  yellowLight.GetComponent<MeshRenderer> ().material = offMaterial;
	  // now just switch on the correct colour
	  switch (colour)
	  {
	    case "red":
              redLight.GetComponent<MeshRenderer> ().material = redMaterial; 
	      break; 
	    case "yellow":
              yellowLight.GetComponent<MeshRenderer> ().material = yellowMaterial; 
	      break; 
	    case "redyellow":
              redLight.GetComponent<MeshRenderer> ().material = redMaterial; 
              yellowLight.GetComponent<MeshRenderer> ().material = yellowMaterial; 
	      break; 
	    case "green": 
              greenLight.GetComponent<MeshRenderer> ().material = greenMaterial; 
	      break; 
	  }
	}
}
