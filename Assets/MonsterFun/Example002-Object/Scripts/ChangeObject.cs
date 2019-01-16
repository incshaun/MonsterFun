using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObject : MonoBehaviour {

        public Color surfaceColour = new Color (0, 1, 0);
        
	// Use this for initialization
	void Start () {
          this.GetComponent<MeshRenderer> ().material.color = surfaceColour;
	}
	
	// Update is called once per frame
	void Update () {
          this.GetComponent<MeshRenderer> ().material.color = 
             new Color (Mathf.Abs (Mathf.Sin (0.37f * Time.time)), 
                        Mathf.Abs (Mathf.Sin (0.71f * Time.time)),
                        Mathf.Abs (Mathf.Sin (0.52f * Time.time)));
		
	}
}
