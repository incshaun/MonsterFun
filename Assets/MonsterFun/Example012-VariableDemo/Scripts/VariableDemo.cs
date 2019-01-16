using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableDemo : MonoBehaviour {

        class Ray
	  {
	    Vector3 origin;
	    Vector3 direction;
	    
	    public Ray (Vector3 o, Vector3 d)
	    {
	      origin = o;
	      direction = d;
	    }
	    public override string ToString ()
	    {
	      return "[" + origin + "->" + direction + "]";
	    }
	  }

	// Use this for initialization
	void Start () {
	  int varThatIsInt = 7;
	  float timeCounter = 37.4f;
	  bool onNotOff = true;
	  print ("Integer variable value: " + varThatIsInt);
	  print ("TimeCounter value: " + timeCounter);
	  print ("Boolean variable's value: " + onNotOff);
	  
	  Vector3 myDirection = new Vector3 (1.0f, 1.5f, -0.3f);
	  Color red = new Color (1, 0, 0);
	  print ("Direction Y: " + myDirection.y);
	  print ("Colour bits: " + red);
	
	  Ray pointerDirection = new Ray (new Vector3 (0,0,0), new Vector3 (1,0,0)); 
	  print ("Ray value: " + pointerDirection);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
