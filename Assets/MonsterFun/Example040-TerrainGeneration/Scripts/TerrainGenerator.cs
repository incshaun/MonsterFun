using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour {

    int indexOfVertex (int x, int y, int sizex, int sizey)
    {
        return x + (y * (sizex + 1));
    }

    int indexOfTriangle (int x, int y, int sizex, int sizey)
    {
        return (3 * 2) * (y * sizex + x);
    }

    public int levels = 8;
    public float initialFrequency = 2.0f;
    public float initialAmplitude = 2.0f;
    public float frequencyFactor = 2.0f;
    public float amplitudeFactor = 0.5f;
    public float patternFrequency = 6.0f;
    public float seed = 94.5f;

    float getHeight (float x, float y)
    {
        float h = 0.0f;
        
        float a = initialAmplitude;
        float f = initialFrequency;
        
        for (int l = 0; l < levels; l++)
        {
            h = h + a * Mathf.PerlinNoise (f * (x + seed), f * (y + seed));
            a = a * amplitudeFactor;
            f = f * frequencyFactor;
        }
        
        return h;
    }

    void On_UpdateMesh ()
    {
        int i;
        int j;
        
        int meshx = 250;
        int meshy = 250;
        
        Vector3 [] vertices = new Vector3 [(meshx + 1) * (meshy + 1)];
        for (i = 0; i <= meshx; i++)
        {
            for (j = 0; j <= meshy; j++)
            {
              float xp = 1.0f * (i - (meshx / 2.0f)) / meshx;   
              float yp = 1.0f * (j - (meshy / 2.0f)) / meshy;
              vertices[indexOfVertex (i, j, meshx, meshy)] = new Vector3 (xp, getHeight (xp, yp), yp);
            }
        }
        
        Vector2 [] uv = new Vector2[(meshx + 1) * (meshy + 1)];
        for (i = 0; i <= meshx; i++)
        {
            for (j = 0; j <= meshy; j++)
            {
				float xp = 1.0f * (i - (meshx / 2.0f)) / meshx;   
				float yp = 1.0f * (j - (meshy / 2.0f)) / meshy;
				float u = Mathf.PerlinNoise (patternFrequency * (xp + seed), patternFrequency * (yp + seed));
				float v = 0.3f * (vertices[indexOfVertex (i, j, meshx, meshy)].y - 0.2f);
                uv[indexOfVertex (i, j, meshx, meshy)] = new Vector2 (u, v);
            }
        }
        
        int [] triangles = new int [3 * 2 * meshx * meshy];
        for (i = 0; i < meshx; i++)
        {
            for (j = 0; j < meshy; j++)
            {
                triangles[indexOfTriangle (i, j, meshx, meshy) + 0] = indexOfVertex (i + 0, j + 0, meshx, meshy);
                triangles[indexOfTriangle (i, j, meshx, meshy) + 1] = indexOfVertex (i + 0, j + 1, meshx, meshy);
                triangles[indexOfTriangle (i, j, meshx, meshy) + 2] = indexOfVertex (i + 1, j + 1, meshx, meshy);

                triangles[indexOfTriangle (i, j, meshx, meshy) + 3] = indexOfVertex (i + 0, j + 0, meshx, meshy);
                triangles[indexOfTriangle (i, j, meshx, meshy) + 4] = indexOfVertex (i + 1, j + 1, meshx, meshy);
                triangles[indexOfTriangle (i, j, meshx, meshy) + 5] = indexOfVertex (i + 1, j + 0, meshx, meshy);            

            }
        }
        
        Mesh mesh = GetComponent <MeshFilter> ().mesh;
        mesh.Clear (false);
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uv;
        mesh.RecalculateNormals ();
    }

    // Use this for initialization
    void Start () {
    }
    
    // Update is called once per frame
    void Update () {
      On_UpdateMesh ();            
      seed += 0.01f;
            
    }
}
