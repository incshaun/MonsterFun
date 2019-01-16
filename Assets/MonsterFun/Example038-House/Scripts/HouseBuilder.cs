using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseBuilder : MonoBehaviour {

    public GameObject brickPrefab;

    public float brickSize = 0.5f;

    public float length = 5.0f;
    public float width = 3.0f;
    public float height = 2.0f;
    public int floors = 5;

    // Build a wall starting at point start. Bricks will be laid for a total wall length of length moving in the direction defined by hdirection.
    // Bricks will be stacked for a total height, moving in the hDirection. The size of individual bricks will be determined by brickSize. Bricks will be made from 
    // the brickPrefab, which is assumed to have unit size in all directions, with its local origin in the center.
    private void buildWall (Vector3 start, Vector3 hdirection, Vector3 hDirection, float length, float height, float brickSize, GameObject brickPrefab)
    {
      Vector3 hStep = hdirection;
      Vector3 vStep = hDirection;

      // For each layer of bricks.
      for (float heighti = 0.0f; heighti < height; heighti += brickSize)
      {
        // Build a row of bricks
        for (float lengthi = 0.0f; lengthi < length; lengthi += brickSize)
          {
            Vector3 brickPos = start + lengthi * hStep + heighti * vStep;
            // Offset to center of brick.
            brickPos += new Vector3 (brickSize / 2, brickSize / 2, brickSize / 2);
            GameObject brick = Instantiate (brickPrefab, brickPos, Quaternion.identity);
            brick.transform.localScale = new Vector3 (brickSize, brickSize, brickSize);
            brick.transform.SetParent (this.transform, false);
          }
      }
    }

    // Create a single object wall, required for structural strength.
    private void buildLintel (Vector3 start, Vector3 hdirection, Vector3 hDirection, float length, float height, float brickSize, GameObject brickPrefab)
    {
      Vector3 brickPos = start + (length / 2) * hdirection + (height / 2) * hDirection + (brickSize / 2) * (new Vector3 (1,1,1) - (hdirection + hDirection));
      GameObject brick = Instantiate (brickPrefab, brickPos, Quaternion.identity);
      brick.transform.localScale = (length * hdirection + height * hDirection + brickSize * (new Vector3 (1,1,1) - (hdirection + hDirection)));
      brick.transform.SetParent (this.transform, false);
    }

    private void buildWallWithDoor (Vector3 start, Vector3 hdirection, Vector3 hDirection, float length, float height, float doorWidth, float doorHeight, float brickSize, GameObject brickPrefab)
    {
      float doorSize = (Mathf.Round (doorWidth / brickSize)) * brickSize; // make sure door is a whole number of bricks in size.
      float doorStart = (Mathf.Round ((length - doorSize) / (2 * brickSize))) * brickSize; // and that the door starts at a whole brick.
      float doorTop = (Mathf.Round (doorHeight / brickSize)) * brickSize; // make sure door is a whole number of bricks in height.

      // left half
      buildWall (start, hdirection, hDirection, doorStart, doorTop, brickSize, brickPrefab);
      // right half
      buildWall (start + new Vector3 (doorStart + doorSize, 0, 0), hdirection, hDirection, length - (doorStart + doorSize), doorTop, brickSize, brickPrefab);

      // lintel
      buildLintel (start + new Vector3 (0, doorTop, 0), hdirection, hDirection, length, brickSize, brickSize, brickPrefab);

      // Layer of bricks above lintel
      buildWall (start + new Vector3 (0, doorTop + brickSize, 0), hdirection, hDirection, length, height - (doorTop + brickSize), brickSize, brickPrefab);
    }

    private void buildWallWithWindow (Vector3 start, Vector3 hdirection, Vector3 hDirection, float length, float height, float windowWidth, float windowBottom, float windowTop, float brickSize, GameObject brickPrefab)
    {
      float windowSize = (Mathf.Round (windowWidth / brickSize)) * brickSize; 
      float windowStart = (Mathf.Round ((length - windowSize) / (2 * brickSize))) * brickSize;
      windowBottom = (Mathf.Round (windowBottom / brickSize)) * brickSize;
      windowTop = (Mathf.Round (windowTop / brickSize)) * brickSize;

      // bottom layer
      buildWall (start, hdirection, hDirection, length, windowBottom, brickSize, brickPrefab);

      // left half
      buildWall (start + windowBottom * hDirection, hdirection, hDirection, windowStart, windowTop - windowBottom, brickSize, brickPrefab);
      // right half
      buildWall (start + (windowStart + windowSize) * hdirection + windowBottom * hDirection, hdirection, hDirection, length - (windowStart + windowSize), windowTop - windowBottom, brickSize, brickPrefab);

      // lintel
      buildLintel (start + windowTop * hDirection, hdirection, hDirection, length, brickSize, brickSize, brickPrefab);

      // Layer of bricks above lintel
      buildWall (start + (windowTop + brickSize) * hDirection, hdirection, hDirection, length, height - (windowTop + brickSize), brickSize, brickPrefab);
    }
    
    // a pitched roof consists of a number of slabs of decreasing size, stacked one about the other.
    private void buildRoof (Vector3 start, Vector3 lDirection, Vector3 wDirection, Vector3 hDirection, float length, float width, float brickSize, GameObject brickPrefab)
    {
      float l = length;
      float w = width;
      float h = 0;
      while ((l > 0) && (w > 0))
      {
        buildRoofSlab (start + h * (hDirection + lDirection + wDirection), lDirection, wDirection, hDirection, l, w, brickSize, brickPrefab);
//         GameObject brick = Instantiate (brickPrefab, brickPos, Quaternion.identity);
//         brick.transform.localScale = (l * lDirection + w * wDirection + brickSize * hDirection);
//         brick.transform.SetParent (this.transform, false);
        l -= 2 * brickSize;
        w -= 2 * brickSize;
        h += brickSize;
      }
    }
    
    // create a slab of length by width bricks with height of 1 brick.
    private void buildRoofSlab (Vector3 start, Vector3 lDirection, Vector3 wDirection, Vector3 hDirection, float length, float width, float brickSize, GameObject brickPrefab)
    {
      float l = length + brickSize;
      float w = width + brickSize;
      float h = brickSize / 2;
      Vector3 brickPos = start + (l / 2) * lDirection + (w / 2) * wDirection + h * hDirection;
      GameObject brick = Instantiate (brickPrefab, brickPos, Quaternion.identity);
      brick.transform.localScale = (l * lDirection + w * wDirection + brickSize * hDirection);
      brick.transform.SetParent (this.transform, false);
    }
    
    // A floor consists of 4 walls (one with door, and one with window, and a flat roof slab.
    private void buildOneFloor (Vector3 start, Vector3 lDirection, Vector3 wDirection, Vector3 hDirection, float length, float width, float height, float brickSize, GameObject brickPrefab)
    {
        // 4 walls
       buildWallWithDoor (start, lDirection, hDirection, length, height, length / 3.0f, height * 2.0f / 3.0f, brickSize, brickPrefab);
       buildWallWithWindow (start + length * lDirection, wDirection, hDirection, width, height, width / 3.0f, height * 1.0f / 3.0f, height * 2.0f / 3.0f, brickSize, brickPrefab);
        buildWall (start + length * lDirection + width * wDirection, -lDirection, hDirection, length, height, brickSize, brickPrefab);
       buildWall (start + width * wDirection, -wDirection, hDirection, width, height, brickSize, brickPrefab);
        
       buildRoofSlab (start + height * hDirection, lDirection, wDirection, hDirection, length, width, brickSize, brickPrefab);
    }
    
    // A house consists of a number of floors, and a pitched roof.
    private void buildHouse (Vector3 start, float length, float width, float wallheight, float brickSize, GameObject brickPrefab)
    {
      // assert: length, width, height must be a multiple of bricksize.
      length = (Mathf.Round (length / brickSize)) * brickSize;
      width = (Mathf.Round (width / brickSize)) * brickSize;
      height = (Mathf.Round (wallheight / brickSize)) * brickSize;

      Vector3 lDirection = new Vector3 (1, 0, 0);
      Vector3 wDirection = new Vector3 (0, 0, 1);
      Vector3 hDirection = new Vector3 (0, 1, 0);

      for (int i = 0; i < floors; i++)
      {
        buildOneFloor (start + (i * (height + brickSize)) * hDirection, lDirection, wDirection, hDirection, length, width, height, brickSize, brickPrefab);
      }

      // roof
      buildRoof (start + ((floors - 1) * (height + brickSize) + brickSize) * hDirection + height * hDirection, lDirection, wDirection, hDirection, length, width, brickSize, brickPrefab);
    }

    void Start () {
      buildHouse (new Vector3 (-length / 2, 0, -width / 2), length, width, height, brickSize, brickPrefab);
    }
}

