using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeDirectionControl : MonoBehaviour {

	public GameObject JudgeObject;
	public GameObject LawyerObject;

	void Start () {
		if (Global.selectedRole == "Judge")
		{
			GameObject mover = GameObject.Find ("UserMovement");
			GameObject judge = GameObject.Find ("Judge");
			GameObject judgebody = GameObject.Find ("JudgeBody");
			GameObject camera = GameObject.Find ("Camera");
			GameObject steamvrcamera = GameObject.Find ("[CameraRig]");
			if ((mover == null) || (judgebody == null) || (judge == null) || (camera == null))
			{
				Debug.Log ("Warning: missing either the UserMovement object or the JudgeBody object or the Camera object");
			}
			mover.GetComponent <MoveObjectManually> ().setActiveUser (judge);
			if (camera != null)
			{
				camera.transform.SetParent (judgebody.transform);
				camera.transform.localPosition = new Vector3 (0, 1.5f, 0);
			}
			if (steamvrcamera != null)
			{
				steamvrcamera.transform.SetParent (judgebody.transform);
				steamvrcamera.transform.localPosition = new Vector3 (0, 0, 1);
				camera.SetActive (false);

				var gavel = GameObject.Find ("Gavel");
				var controller = steamvrcamera.transform.Find ("Controller (left)");
				gavel.transform.SetParent (controller.transform);
				gavel.transform.localPosition = new Vector3 (0, 0, 0);
			}
		}


	}

	void Update () {
		Vector3 lookDirection = LawyerObject.transform.position - JudgeObject.transform.position;
		lookDirection.y = 0;
		JudgeObject.transform.rotation = Quaternion.LookRotation (lookDirection);
	}
}
