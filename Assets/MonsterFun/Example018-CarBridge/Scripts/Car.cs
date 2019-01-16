using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {

        public Bridge bridge;
        
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
	  this.transform.position += new Vector3 (0.01f, 0, 0);
	  if (bridge != null)
	  {
	    if (this.transform.position.x > 3.0f)
	    {
	      bridge.open ();
	    }
	    else if (this.transform.position.x > -3.0f)
	    {
	      bridge.close ();
	    }
	  }
	}
}
