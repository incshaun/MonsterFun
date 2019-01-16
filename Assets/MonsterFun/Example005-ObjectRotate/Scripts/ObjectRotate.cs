using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
          this.transform.rotation = Quaternion.AngleAxis (37.0f, new Vector3 (0.4f, 0.5f, -0.3f));
	}
	
	// Update is called once per frame
	void Update () {
          this.transform.rotation = this.transform.rotation * Quaternion.AngleAxis (0.7f, new Vector3 (0.1f, 0.5f, -0.1f));
//          this.transform.RotateAround (new Vector3 (0.0f, 0.0f, 0.0f), new Vector3 (0.1f, 0.5f, -0.1f), 0.7f);
//          this.transform.Rotate (0.1f, 0.2f, 0.3f);
	}
}
