using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonControl : MonoBehaviour {

        // limit of side to side movement.
        public float sideAngleRange = 30.0f;
        
        // limit of elevation
        public float minElevation = 5.0f;
        public float maxElevaction = 80.0f;
        
        // control sensitivity factor.
        public float sensitivity = 10.0f;
        
        private float elevation = 0.0f;
        private float side = 0.0f;
        
        public GameObject avianPrefab;
        
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	  float v = Input.GetAxis ("Vertical");
	  float h = Input.GetAxis ("Horizontal");
	  
	  side = Mathf.Max (Mathf.Min (side + h * sensitivity, sideAngleRange), -sideAngleRange);
	  elevation = Mathf.Max (Mathf.Min (elevation + v * sensitivity, maxElevaction), minElevation);
          this.transform.rotation = Quaternion.AngleAxis (side, new Vector3 (0,1,0)) * Quaternion.AngleAxis (elevation, new Vector3 (1,0,0));
          
          if (Input.GetAxis ("Fire1") > 0)
          {
            GameObject avian = Instantiate (avianPrefab, this.transform.position, this.transform.rotation);
            avian.GetComponent <AvianFlu> ().velocity = 100.0f * this.transform.up;
          }
	}
}
