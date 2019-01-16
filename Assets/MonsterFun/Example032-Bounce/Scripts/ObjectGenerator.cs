using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour {

        // The object that will be created.
        public GameObject objectPrefab;
        
        // the number of objects created per second.
        public float rate = 1.0f;

        private float counter = 0.0f;
        
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
          counter += Time.deltaTime;
          if (counter > 1.0f / rate)
          {
            GameObject ob = Instantiate (objectPrefab);
            ob.GetComponent <MeshRenderer> ().material.color = new Color (0.5f + Random.Range (0.0f, 0.5f), 0.5f + Random.Range (0.0f, 0.5f), 0.5f + Random.Range (0.0f, 0.5f));
            counter = 0.0f;
          }
		
	}
}
