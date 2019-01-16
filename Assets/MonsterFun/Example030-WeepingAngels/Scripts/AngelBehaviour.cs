using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelBehaviour : MonoBehaviour {

	enum AngelStates { NotInit, Follow, Freeze, Retreat, Bounce, Attack };

	// Current state in the state transition graph.
	private AngelStates state = AngelStates.NotInit;

	// speed of movement while following.
	private float speedFollow = 0.5f;

	// proximity threshold
	private float proximityLimit = 3.0f;

	// time limit on being frozen.
	private float freezeTimeLimit = 2.0f;

	// time limit on bouncing before attack.
	private float bounceTimeLimit = 5.0f;

	// the player that is being chased.
	private GameObject player;

	// coroutine used for the timer, so we can abort it if required.
	IEnumerator timerCoroutine;

	// This function updates the lawyer simulation according to the state involved.
	void setState (AngelStates newState)
	{
		if (state == newState)
		{
			return; // nothing changed.
		}

		AngelStates oldState = state;
		state = newState;

		handleStateChangedEvent (oldState, newState);
	}

	// Event handlers. Each event handler should be well behaved, and not take
	// any longer than absolutely essential. 

	// Make any changes to the scene corresponding to arriving in the given state.
	// The previous state is provided, but usually not required.
	void handleStateChangedEvent (AngelStates oldState, AngelStates state)
	{
		// tidy up after any old states.
		switch (oldState) {
		case AngelStates.Freeze: clearTimer (); break;
		case AngelStates.Bounce: clearTimer (); transform.position = new Vector3 (transform.position.x, 0.0f, transform.position.z); break;
		}

		// For most new states, we set the colour of the object, mostly to 
		// provide a visual indication of the current state.
		switch (state)
		{
		case AngelStates.Follow: this.GetComponent <MeshRenderer> ().material.color = new Color (1, 1, 1, 0.2f); break;
		case AngelStates.Attack: this.GetComponent <MeshRenderer> ().material.color = new Color (1, 0, 0, 0.2f); break;
		case AngelStates.Freeze: this.GetComponent <MeshRenderer> ().material.color = new Color (0.1f, 0.1f, 0.1f, 0.2f); startTimer (freezeTimeLimit); break;
		case AngelStates.Retreat: this.GetComponent <MeshRenderer> ().material.color = new Color (0.3f, 0.3f, 0.7f, 0.2f); break;
		case AngelStates.Bounce: this.GetComponent <MeshRenderer> ().material.color = new Color (0.3f, 0.8f, 0.2f, 0.2f); startTimer (bounceTimeLimit); break;
		}
	}

	// All event changes resulting from collisions. This is the collisionEventHandler function.
	void OnTriggerEnter (Collider other) 
	{
	}

	// State changes as a result of getting too close.
	void handleProximityEvent ()
	{
		switch (state)
		{
		case AngelStates.Follow: setState (AngelStates.Attack); break;
		case AngelStates.Freeze: setState (AngelStates.Bounce); break;
		}
	}

	// State changes as a result of being too far apart.
	void handleUnproximityEvent ()
	{
		switch (state)
		{
		case AngelStates.Bounce: setState (AngelStates.Retreat); break;
		}
	}

	// State changes as a result of looking at a object.
	void handleLookedAtEvent ()
	{
		switch (state)
		{
		case AngelStates.Follow: setState (AngelStates.Freeze); break;
		}
	}

	// State changes as a result of not looking at an object.
	void handleUnlookedAtEvent ()
	{
		switch (state)
		{
		case AngelStates.Retreat: setState (AngelStates.Follow); break;
		}
	}

	// Respond to a timer event, based on what state we're in.
	void handleTimerEvent ()
	{
		switch (state)
		{
		case AngelStates.Freeze: setState (AngelStates.Retreat); break;
		case AngelStates.Bounce: setState (AngelStates.Attack); break;
		}
	}

	// Returns true if the current object is visible - within
	// fieldOfView degrees of the player's direction of gaze.
	bool isVisible (float fieldOfView)
	{
		Vector3 gazeDir = player.transform.forward;
		// get the direction to the current object.
		Vector3 actualDir = transform.position - player.transform.position;
		actualDir.Normalize ();

		float cosAngle = Vector3.Dot (gazeDir, actualDir);
		if (cosAngle > Mathf.Cos (fieldOfView * Mathf.PI / 180.0f)) {
			return true;
		}
		return false;
	}

	// Sleep for a while and then generate a timer event.
	IEnumerator deferredTimerEvent (float timeDelay)
	{
		yield return new WaitForSeconds (timeDelay);
		handleTimerEvent ();
	}

	// trigger a timer event after the specified time in seconds.
	void startTimer (float duration)
	{
		timerCoroutine = deferredTimerEvent (duration); 
		StartCoroutine (timerCoroutine);
	}

	// clear any timers running at the moment.
	void clearTimer ()
	{
		StopCoroutine (timerCoroutine);
	}

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Avatar");

		setState (AngelStates.Follow);
	}
	
	// Update is called once per frame
	void Update () {
		// generate any events required.
		// Proximity.
		Vector3 dir = player.transform.position - transform.position;
		if (dir.magnitude < proximityLimit) {
			handleProximityEvent ();
		} else if (dir.magnitude > 1.5f * proximityLimit) { 
			// actually have to move a significant distance beyond proximity
			// limit, to avoid change being too sensitive to small movements.
			handleUnproximityEvent ();
		}

		// Visibility.
		if (isVisible (40.0f)) {
			handleLookedAtEvent ();
		} else {
			handleUnlookedAtEvent ();
		}

		// handle any updates specific to the current state.
		switch (state)
		{
		case AngelStates.Follow:
			{
				dir = player.transform.position - transform.position;
				dir.Normalize ();
				transform.position += speedFollow * Time.deltaTime * dir; 
				transform.forward = dir;
			}
			break;
		case AngelStates.Freeze:
			break;
		case AngelStates.Retreat:
			{
				dir = -(player.transform.position - transform.position);
				dir.Normalize ();
				transform.position += speedFollow * Time.deltaTime * dir; 
				transform.forward = dir;
			}
			break;
		case AngelStates.Bounce:
			{
				transform.position = new Vector3 (transform.position.x, Mathf.Abs (Mathf.Sin (Time.time)), transform.position.z); 
			}
			break;
		}
	}
}

