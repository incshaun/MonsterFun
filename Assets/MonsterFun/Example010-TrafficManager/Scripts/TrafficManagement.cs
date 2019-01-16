using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficManagement : MonoBehaviour {

        public GameObject lightA;
        public GameObject lightB;
        public GameObject lightC;
        public GameObject lightD;
        
	// Use this for initialization
	void Start () {
	  StartCoroutine (cycleLights ());	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	IEnumerator cycleLights() {
	  while (true)
	  {
	    lightA.GetComponent <TrafficLightOperations> ().setColour ("green");
	    lightC.GetComponent <TrafficLightOperations> ().setColour ("green");
	    lightB.GetComponent <TrafficLightOperations> ().setColour ("red");
	    lightD.GetComponent <TrafficLightOperations> ().setColour ("red");
	    yield return new WaitForSeconds (1);
	    lightA.GetComponent <TrafficLightOperations> ().setColour ("yellow");
	    lightC.GetComponent <TrafficLightOperations> ().setColour ("yellow");
	    lightB.GetComponent <TrafficLightOperations> ().setColour ("red");
	    lightD.GetComponent <TrafficLightOperations> ().setColour ("red");
	    yield return new WaitForSeconds (1);
	    lightA.GetComponent <TrafficLightOperations> ().setColour ("red");
	    lightC.GetComponent <TrafficLightOperations> ().setColour ("red");
	    lightB.GetComponent <TrafficLightOperations> ().setColour ("red");
	    lightD.GetComponent <TrafficLightOperations> ().setColour ("red");
	    yield return new WaitForSeconds (1);
	    lightA.GetComponent <TrafficLightOperations> ().setColour ("red");
	    lightC.GetComponent <TrafficLightOperations> ().setColour ("red");
	    lightB.GetComponent <TrafficLightOperations> ().setColour ("green");
	    lightD.GetComponent <TrafficLightOperations> ().setColour ("green");
	    yield return new WaitForSeconds (1);
	    lightA.GetComponent <TrafficLightOperations> ().setColour ("red");
	    lightC.GetComponent <TrafficLightOperations> ().setColour ("red");
	    lightB.GetComponent <TrafficLightOperations> ().setColour ("yellow");
	    lightD.GetComponent <TrafficLightOperations> ().setColour ("yellow");
	    yield return new WaitForSeconds (1);
	    lightA.GetComponent <TrafficLightOperations> ().setColour ("red");
	    lightC.GetComponent <TrafficLightOperations> ().setColour ("red");
	    lightB.GetComponent <TrafficLightOperations> ().setColour ("red");
	    lightD.GetComponent <TrafficLightOperations> ().setColour ("red");
	    yield return new WaitForSeconds (1);
	  }
	}
}
