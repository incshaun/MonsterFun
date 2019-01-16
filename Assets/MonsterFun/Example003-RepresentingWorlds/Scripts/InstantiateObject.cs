using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObject : MonoBehaviour {

        public GameObject objectTemplate;

	// Use this for initialization
	void Start () {
          GameObject objectInstance = Instantiate (objectTemplate, new Vector3 (5, 0, 2), Quaternion.identity);
          objectInstance.transform.parent = null;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
