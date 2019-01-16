using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour {

        public GameObject bridgeSection1;
        public GameObject bridgeSection2;

        private bool bridgeOpen;
        
	// Use this for initialization
	void Start () {
	  bridgeOpen = false;
	  open ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void open ()
	{
	  if (!bridgeOpen)
	  {
	    bridgeSection1.transform.rotation = Quaternion.AngleAxis (45.0f, new Vector3 (0,0,1));
	    bridgeSection2.transform.rotation = Quaternion.AngleAxis (-45.0f, new Vector3 (0,0,1));
	    bridgeOpen = true;
	  }
	}

	public void close ()
	{
	  if (bridgeOpen)
	  {
	    bridgeSection1.transform.rotation = Quaternion.AngleAxis (0.0f, new Vector3 (0,0,1));
	    bridgeSection2.transform.rotation = Quaternion.AngleAxis (0.0f, new Vector3 (0,0,1));
	    bridgeOpen = false;
	  }
	}
}
