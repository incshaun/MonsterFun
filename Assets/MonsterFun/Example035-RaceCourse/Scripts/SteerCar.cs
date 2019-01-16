using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SteerCar : NetworkBehaviour {

        public float forceEffect = 10.0f;
        public float angleRate = 10.0f;
        
        void Start ()
        {
          if (isLocalPlayer)
          {
            GameObject camera = GameObject.Find ("Main Camera");
            if (camera != null)
            {
              camera.transform.parent = this.transform;
              camera.transform.position = new Vector3 (0, 3, -2);
            }
          }
        }
        
	void Update () {
	  if (isLocalPlayer)
	  {
            float h = Input.GetAxis ("Horizontal");
            float v = Input.GetAxis ("Vertical");
            
            GetComponent <Rigidbody> ().AddForce (forceEffect * v * transform.forward);
            transform.localRotation *= Quaternion.AngleAxis (angleRate * h, transform.up);
          }
	}
}
