using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalustradeChain : MonoBehaviour {

	// Just a tag to identify purpose of this copy of the script component.
	public string LabelForThisChain;

	// Parameters
	public GameObject balustradePrefab;
	public Vector3 startingPoint;
	public Vector3 direction;
	public int numberOfUnits;

	// Build a linear sequence from the prefab elements, placed at startingPoint with steps in the given direction. The length
	// of the chain is set by the numberOfUnits. 
	// Elements instantiated are made children of the game object for which this script is a component. 
	// The orientation of the piece is infered from the direction - assuming that elements are aligned along the x axis by default.
	void buildBalustradeChain (GameObject balustradePrefab, Vector3 startingPoint, Vector3 direction, int numberOfUnits)
	{
		for (int unit = 0; unit < numberOfUnits; unit++)
		{
			GameObject balustradeElement = Instantiate (balustradePrefab, startingPoint + unit * direction, Quaternion.identity);
			balustradeElement.transform.SetParent (this.gameObject.transform);
		}
	}

	void Start () {
		buildBalustradeChain (balustradePrefab, startingPoint, direction, numberOfUnits);
	}

	void Update () {

	}
}
