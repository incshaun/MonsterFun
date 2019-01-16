using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertyModifier : MonoBehaviour {

	// Use this for initialization
	void Start () {
	  GameObject cubeObject = GameObject.Find ("Cube");
	  GameObject sphereObject = GameObject.Find ("Sphere");
	  GameObject cylinderObject = GameObject.Find ("Cylinder");
	  
	  // Move the cube 2 units to the left.
	  cubeObject.transform.position = new Vector3 (-2.0f, 0.0f, 0.0f);
	  // Move the sphere 3 units upwards.
	  sphereObject.transform.position = new Vector3 (0.0f, 3.0f, 0.0f);
	  // Set the cylinder material colour to red.
	  cylinderObject.GetComponent<Renderer>().materials[0].color = new Color (1.0f, 0.0f, 0.0f);
	  // Copy the shape of the cylinder to the shape of the cube.
	  cubeObject.GetComponent<MeshFilter>().mesh = cylinderObject.GetComponent<MeshFilter>().mesh;
	  // Rotate the cube object (which now looks like a cylinder).
	  cubeObject.transform.rotation = Quaternion.AngleAxis (45.0f  , new Vector3 (1.0f, 1.0f, 1.0f));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
