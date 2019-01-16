using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGenerator : MonoBehaviour {

        [Tooltip ("For example, use a unit scale sphere at origin.")]
        public GameObject leafPrefab;  
        [Tooltip ("For example, use a unit cylinder from origin to y=1.")]
        public GameObject branchPrefab; 

        [Tooltip ("The number of levels of recursion (number of generations of branches before we get to a leaf)")]
        public int levels = 5;
        [Tooltip ("How many banches branch out of a branch.")]
        public int branchFactor = 4;
        [Tooltip ("The angle between a branch and the next (sub)branch.")]
        public float branchAngle = 45.0f;
        [Tooltip ("The initial scale (length) of the trunk.")]
        public float trunkLength = 3.0f;
        [Tooltip ("The length of a subbranch relative to the length of its parent.")]
        public float trunkDecayFactor = 0.5f;

	void Start () {
	  generateTree (levels, transform.position, transform.rotation, trunkLength);	
	}
	
        void generateTree (int levels, Vector3 position, Quaternion direction, float trunkLength)
        {
          if (levels == 0)
          {
            GameObject leaves = Instantiate (leafPrefab, position, direction);
          }
          else
          {
            GameObject branch = Instantiate (branchPrefab, position, direction);
            branch.transform.localScale = new Vector3 (1, trunkLength, 1);
            Vector3 endOfBranchPosition = branch.transform.position + trunkLength * branch.transform.up;

            for (int i = 0; i < branchFactor; i++)
            {
              Quaternion newBranchDirection = direction * Quaternion.AngleAxis (i * 360 / branchFactor, Vector3.up);
              newBranchDirection = newBranchDirection * Quaternion.AngleAxis (branchAngle, Vector3.right);
              generateTree (levels - 1, endOfBranchPosition, newBranchDirection, trunkLength * trunkDecayFactor);
            }
          }
        }
	
}


