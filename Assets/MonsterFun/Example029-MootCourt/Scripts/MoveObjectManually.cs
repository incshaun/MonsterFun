using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectManually : MonoBehaviour {

	private GameObject activeUser;
	public float speed = 5.0f;

	void moveInDirection (GameObject thisObject, float forwardAmount, float rightAmount, float timeStep, float speed)
	{
		thisObject.transform.position += speed * timeStep * (forwardAmount * thisObject.transform.forward + rightAmount * thisObject.transform.right);
	}

	void handleMovementControls (GameObject objectToMove, float timeStep, float speed)
	{
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");
		moveInDirection (objectToMove, vertical, horizontal, timeStep, speed);
	}

	void Start () {

	}

	void Awake ()
	{
		activeUser = null;
	}	

	void Update () {
      if (activeUser != null)
		{
			handleMovementControls (activeUser, Time.deltaTime, speed);
		}

	}

	// Sets the object provided as parameter as the active user object to
	// be controlled by the movement controls in this script.
	public void setActiveUser (GameObject user)
	{
		activeUser = user;
	}
}


