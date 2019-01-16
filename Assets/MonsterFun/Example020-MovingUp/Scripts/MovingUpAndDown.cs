using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Move the object up and down between the bounds defined.
public class MovingUpAndDown : MonoBehaviour {

        public float upperBound = 3;
        public float lowerBound = -2;

        private bool directionUp = true;
        
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
          print ("Update function running");
          if (this.transform.position.y > upperBound)
          {
            print ("Moving downwards");
            directionUp = false;
            this.transform.position += new Vector3 (0, -0.1f, 0);
          }
          if (this.transform.position.y < lowerBound)
          {
            print ("Moving upwards");
            directionUp = true;
            this.transform.position += new Vector3 (0, 0.1f, 0);
          }
	}
}
