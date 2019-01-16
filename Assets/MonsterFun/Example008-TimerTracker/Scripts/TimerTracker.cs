using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTracker : MonoBehaviour {

        // The starting value for the timer. This will be set in
        // the Unity editor.
        public float startingTimeValue = 120.0f;

        // The current time value in seconds that the timer displays.
        private float timeLeft;
        
	// Use this for initialization
	void Start () {
          // initialize the timer value from the starting value provided.
          timeLeft = startingTimeValue;
          showTime ();
	}
	
	// Update is called once per frame
	void Update () {
	  // decrease timer value according to the time that has passed
	  // since the last Update.
	  timeLeft = timeLeft - Time.deltaTime;
	  showTime ();
	}
	
	// Convert the timeLeft into hours, minutes and seconds
	// and update the text display to show this.
	private void showTime ()
	{
	  int hours = ((int) timeLeft) / 3600;
	  int minutes = (((int) timeLeft) % 3600) / 60;
	  int seconds = ((int) timeLeft) % 60;
	  this.GetComponent <TextMesh>().text = hours.ToString ("D2") + 
	    ":" + minutes.ToString ("D2") + ":" + seconds.ToString ("D2");
	}
}
