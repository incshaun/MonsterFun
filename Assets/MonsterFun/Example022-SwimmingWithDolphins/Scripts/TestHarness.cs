using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHarness : MonoBehaviour {

        void testSeaCheckClass ()
        {
          SeaCheck seaCheck;
          
          seaCheck = new SeaCheck (-5, 5);
          if (seaCheck.inSea (0.0f) == true)
          {
            print ("SeaCheck, test A successful");
          }
          else
          {
            print ("SeaCheck, test A failed");
          }
          if (seaCheck.inSea (-10.0f) == false)
          {
            print ("SeaCheck, test B successful");
          }
          else
          {
            print ("SeaCheck, test B failed");
          }
          if (seaCheck.inSea (10.0f) == false)
          {
            print ("SeaCheck, test C successful");
          }
          else
          {
            print ("SeaCheck, test C failed");
          }
          
          seaCheck = new SeaCheck (0, 1);
          if (seaCheck.inSea (0.5f) == true)
          {
            print ("SeaCheck, test D successful");
          }
          else
          {
            print ("SeaCheck, test D failed");
          }
          
        }

	// Use this for initialization
	void Start () {
	  // Runs some unit tests.
	  // Disable the object in the scene to disable testing.
	  testSeaCheckClass ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
