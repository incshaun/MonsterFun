using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Place pegs in the arrangement of a bean machine/Galton Board/quincunx
public class QuincunxGenerator : MonoBehaviour {

	[Tooltip ("Position of the apex peg in the triangular formation")]
	public Vector3 topPegPosition = new Vector3 (0, 20, 0);

	[Tooltip ("Horizontal gap between pegs")]
	public float horizontalgap = 2.0f;
	[Tooltip ("Vertical gap between pegs")]
	public float verticalgap = 3.0f;

	[Tooltip ("Number of rows of pegs")]
	public int numberOfRows = 10;

	[Tooltip ("The template for one peg")]
	public GameObject pegTemplate;

	// Place pegs in a staggered triangular formation, from the top point, with spacing
	// defined by hgap horizontally, and vgap vertically.
	// X axis is horizontal, Y axis is vertical.
	void createQuincunx (Vector3 top, float hgap, float vgap, int numRows, GameObject peg)
	{
		int numElementsInCurrentRow = 1;
		float startingX = top.x;

		// lay down one row at a time.
		for (int i = 0; i < numRows; i++) {
			// lay down a row.
			for (int j = 0; j < numElementsInCurrentRow; j++) {
				GameObject pegPiece = Instantiate (peg, new Vector3 (startingX + j * hgap, top.y - i * vgap, 0.0f), Quaternion.identity);
				pegPiece.transform.SetParent (this.transform);
			}
			// shift left edge.
			startingX -= (hgap / 2.0f);
			numElementsInCurrentRow += 1;
		}
	}

	// Use this for initialization
	void Start () {
		createQuincunx (topPegPosition, horizontalgap, verticalgap, numberOfRows, pegTemplate);
	}
}
