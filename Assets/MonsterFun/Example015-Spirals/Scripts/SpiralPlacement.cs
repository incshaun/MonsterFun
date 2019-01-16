using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralPlacement : MonoBehaviour {

        public GameObject objectTemplate;
        
        public int totalNumberOfObjects = 100;
        public float distanceApart = 5.0f;
        public float initialRadius = 5.0f;
        public float radiusIncreasePerRotation = 3.0f;
        
	// Use this for initialization
	void Start () {
	  float anglePerStep;
          float radiusChangePerStep;
	
	  int i;
	  float radius;
	  float angle;
          for (i = 0, radius = initialRadius, angle = 0; 
               i < totalNumberOfObjects; 
               i++, radius += radiusChangePerStep, angle += anglePerStep)
          {
            anglePerStep = distanceApart / radius;
            radiusChangePerStep = radiusIncreasePerRotation * anglePerStep / 2.0f * Mathf.PI;
            print (i + "," + angle + "," + radius);
            float x = radius * Mathf.Sin (angle);
            float y = radius * Mathf.Cos (angle);
            
            GameObject instance = Instantiate (objectTemplate, new Vector3 (x, 0, y), Quaternion.identity);
            instance.transform.SetParent (this.transform);
          }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
