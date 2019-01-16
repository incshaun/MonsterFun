using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Move the object up and down between the bounds defined.
public class FixedMovingUpAndDown : MonoBehaviour {

        public float upperBound = 3;
        public float lowerBound = -2;

	private Vector3 directionIncrement = new Vector3 (0, 0.1f, 0);
        
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
          if (this.transform.position.y > upperBound)
          {
            directionIncrement = new Vector3 (0, -0.1f, 0);
          }
          if (this.transform.position.y < lowerBound)
          {
			directionIncrement = new Vector3 (0, 0.1f, 0);
          }
		this.transform.position += directionIncrement;
	}
}
