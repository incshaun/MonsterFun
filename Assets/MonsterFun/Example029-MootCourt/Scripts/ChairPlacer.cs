using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairPlacer : MonoBehaviour {

	// Unused - just an identifier for what the script is used for in each case.
	public string LabelForThisBlock;

	// Parameters.
	public GameObject chairPrefab;
	public Vector3 startPosition;
	public float yRotation;
	public int xNumberOfChairs;
	public int zNumberOfChairs;
	public float chairGapDistance;

	// Instantiate a grid of objects using the chairPrefab as the template object. These are positioned in a regular axis-aligned grid in the x and z directions, offset
	// by multiples of chairGapDistance from the startPosition. The size of the grid xNumberOfChairs by zNumberOfChairs. Each object can have a rotation about the y axis
	// by the given amount in degrees.
	// All objects are made children of the game object containing this script.
	void createChairs (GameObject chairPrefab, Vector3 startPosition, float yRotation, int xNumberOfChairs, int zNumberOfChairs, float chairGapDistance)
	{
		for (int xChair = 0; xChair < xNumberOfChairs; xChair += 1)
		{
			for (int zChair = 0; zChair < zNumberOfChairs; zChair += 1)
			{
				GameObject chair = Instantiate (chairPrefab, startPosition + new Vector3 (xChair * chairGapDistance, 0, zChair * chairGapDistance), Quaternion.AngleAxis (yRotation, new Vector3 (0,1,0)));
				chair.transform.SetParent (this.gameObject.transform);
			}
		}
	}


	void Start () {
		createChairs (chairPrefab, startPosition, yRotation, xNumberOfChairs, zNumberOfChairs, chairGapDistance);
	}

	void Update () {

	}
}
