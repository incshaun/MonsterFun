using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvianFlu : MonoBehaviour {

        private Vector3 acceleration = new Vector3 (0,-10,0);
        public Vector3 velocity = new Vector3 (0,0,0);

	// Update is called once per frame
	void Update () {
          velocity = velocity + Time.deltaTime * acceleration;
          this.transform.position = this.transform.position + Time.deltaTime * velocity;
	}
}
