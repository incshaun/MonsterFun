using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectatorSimulator : MonoBehaviour {

	// The object used to create spectators.
	public GameObject spectatorPrefab;

	// The starting point for spectators.
	public Vector3 startingPoint;

	// The destination seating block starting point.
	public float seatingStartX;
	public float seatingStartZ;
	// The seating block size.
	public float seatingRangeX;
	public float seatingRangeZ;

	// The gap between seats
	public float chairGap;

	// Move in the x direction first, or the z?
	public bool XFirst;

	// average time between spectators arriving.
	public float averageArrivalInterval;

	public float speed = 1.0f;

	private GameObject currentObject;
	private float destX;
	private float destZ;


	void Start () {
		currentObject = null;

		StartCoroutine (addSpectator (averageArrivalInterval));
	}

	void Update () {
		if (currentObject != null)
		{
			// work out how far still to go.
			float dirx = destX - currentObject.transform.position.x;
			float dirz = destZ - currentObject.transform.position.z;

			float stepx = 0;
			float stepz = 0;

			if (XFirst)
			{
				if (dirx != 0)
				{
					stepx = dirx;
				}
				else
				{
					stepz = dirz;
				}
			}
			else
			{
				if (dirz != 0)
				{
					stepz = dirz;
				}
				else
				{
					stepx = dirx;
				}
			}

			// regulate speed.
			float length = new Vector3 (stepx, 0, stepz).magnitude;
			float maxstepx = Time.deltaTime * speed * stepx / length;
			float maxstepz = Time.deltaTime * speed * stepz / length;
			if (length == 0.0f) {
				maxstepx = 0.0f;
				maxstepz = 0.0f;
			}

			// If we don't have far to go, then step there directly.
			if (Mathf.Abs (maxstepx) > Mathf.Abs (stepx))
			{
				maxstepx = stepx;
			}
			if (Mathf.Abs (maxstepz) > Mathf.Abs (stepz))
			{
				maxstepz = stepz;
			}

			currentObject.transform.position += new Vector3 (maxstepx, 0, maxstepz);

			//Debug.Log (currentObject.transform.position + " _ " + stepx + " " + stepz);

			// reached seat.
			if ((dirx == 0) && (dirz == 0))
			{
				currentObject = null;
				StartCoroutine (addSpectator (averageArrivalInterval));
			}
		}

	}

	IEnumerator addSpectator (float interval)
	{
		yield return new WaitForSeconds (Random.Range (0, interval)); 

		currentObject = Instantiate (spectatorPrefab, startingPoint, Quaternion.AngleAxis (180, Vector3.up));
		// find random position, but on a complete chair.
		destX = seatingStartX + Mathf.Floor (Random.Range (0, seatingRangeX) / chairGap) * chairGap;
		destZ = seatingStartZ + Mathf.Floor (Random.Range (0, seatingRangeZ) / chairGap) * chairGap;

		if (Global.selectedRole == "Spectator") {
			GameObject mover = GameObject.Find ("UserMovement");
			GameObject camera = GameObject.Find ("Camera");
			GameObject steamvrcamera = GameObject.Find ("[CameraRig]");

			if ((mover == null) || (camera == null)) {
				Debug.Log ("Warning: missing either the UserMovement object or the Camera object");
			}
			mover.GetComponent <MoveObjectManually> ().setActiveUser (currentObject);
			if (camera != null) {
				camera.transform.SetParent (currentObject.transform);
				camera.transform.localPosition = new Vector3 (0, 1.5f, 0);
			}
			if (steamvrcamera != null) {
				steamvrcamera.transform.SetParent (currentObject.transform);
				steamvrcamera.transform.localPosition = new Vector3 (0, 0, -1);
				camera.SetActive (false);
			}

		}
	}
}
