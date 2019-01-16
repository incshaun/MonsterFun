using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKSolver : MonoBehaviour {

	public GameObject LFootTarget;
	public GameObject RFootTarget;
	public GameObject LHandTarget;
	public GameObject RHandTarget;
	public GameObject HeadTarget;

	public bool enable = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnAnimatorIK () {
		if (enable) {
			GetComponent <Animator> ().SetIKPositionWeight (AvatarIKGoal.LeftFoot, 1);
			GetComponent <Animator> ().SetIKRotationWeight (AvatarIKGoal.LeftFoot, 1);
			GetComponent <Animator> ().SetIKPosition (AvatarIKGoal.LeftFoot, LFootTarget.transform.position);
			GetComponent <Animator> ().SetIKRotation (AvatarIKGoal.LeftFoot, LFootTarget.transform.rotation);

			GetComponent <Animator> ().SetIKPositionWeight (AvatarIKGoal.RightFoot, 1);
			GetComponent <Animator> ().SetIKRotationWeight (AvatarIKGoal.RightFoot, 1);
			GetComponent <Animator> ().SetIKPosition (AvatarIKGoal.RightFoot, RFootTarget.transform.position);
			GetComponent <Animator> ().SetIKRotation (AvatarIKGoal.RightFoot, RFootTarget.transform.rotation);

			GetComponent <Animator> ().SetIKPositionWeight (AvatarIKGoal.LeftHand, 1);
			GetComponent <Animator> ().SetIKRotationWeight (AvatarIKGoal.LeftHand, 1);
			GetComponent <Animator> ().SetIKPosition (AvatarIKGoal.LeftHand, LHandTarget.transform.position);
			GetComponent <Animator> ().SetIKRotation (AvatarIKGoal.LeftHand, LHandTarget.transform.rotation);

			GetComponent <Animator> ().SetIKPositionWeight (AvatarIKGoal.RightHand, 1);
			GetComponent <Animator> ().SetIKRotationWeight (AvatarIKGoal.RightHand, 1);
			GetComponent <Animator> ().SetIKPosition (AvatarIKGoal.RightHand, RHandTarget.transform.position);
			GetComponent <Animator> ().SetIKRotation (AvatarIKGoal.RightHand, RHandTarget.transform.rotation);

			GetComponent <Animator> ().SetLookAtWeight (1);
			GetComponent <Animator> ().SetLookAtPosition (HeadTarget.transform.position);

		} else {
			GetComponent <Animator> ().SetIKPositionWeight (AvatarIKGoal.LeftFoot, 0);
			GetComponent <Animator> ().SetIKRotationWeight (AvatarIKGoal.LeftFoot, 0);

			GetComponent <Animator> ().SetIKPositionWeight (AvatarIKGoal.RightFoot, 0);
			GetComponent <Animator> ().SetIKRotationWeight (AvatarIKGoal.RightFoot, 0);

			GetComponent <Animator> ().SetIKPositionWeight (AvatarIKGoal.LeftHand, 0);
			GetComponent <Animator> ().SetIKRotationWeight (AvatarIKGoal.LeftHand, 0);

			GetComponent <Animator> ().SetIKPositionWeight (AvatarIKGoal.RightHand, 0);
			GetComponent <Animator> ().SetIKRotationWeight (AvatarIKGoal.RightHand, 0);
		
			GetComponent <Animator> ().SetLookAtWeight (0);
		}
	}
}
