using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureGenerate : MonoBehaviour {

    public float frequency = 5.0f;
    public float phase = 0.0f;
    public float amplitude = 1.0f;

    public float frequencyX = 5.0f;
    public float frequencyY = 5.0f;


    Color noise (float u, float v)
    {
        float brightness = amplitude * Mathf.PerlinNoise (frequencyX * u + phase, frequencyY * v + phase);
        return new Color (brightness, brightness, brightness);
    }

    Color stripes (float u, float v)
    {
        float brightness;
        brightness = (amplitude * Mathf.Sin (frequency * (0.3f * u + 0.5f * v) + phase) + 1.0f) / 2.0f;
        return new Color (brightness, brightness, brightness);
    }

    public float stripeFrequency = 100.0f;
    public float seed = 4352.32423f;
    public float grainFineness = 10.0f;
    public float wriggleFrequencyU = 30.0f;
    public float wriggleFrequencyV = 10.0f;
    public float wriggleAmplitude = 0.07f;

    public Color woodColor = new Color (150.0f / 255.0f, 111.0f / 255.0f, 70.0f / 255.0f);
    public Color grainColor = new Color (80.0f / 255.0f, 41.0f / 255.0f, 0.0f / 255.0f);

    Color wood (float u, float v)
    {
        float wriggle = wriggleAmplitude * Mathf.PerlinNoise (wriggleFrequencyU * u + seed, wriggleFrequencyV * v + seed);
        //return Color (wriggle, wriggle, wriggle);
        
        float stripe = 0.5f + 0.5f * Mathf.Sin (stripeFrequency * (u + wriggle) + seed);
        stripe = Mathf.Pow (stripe, grainFineness);
        //return Color (stripe, stripe, stripe);
        
        return (1.0f - stripe) * woodColor + stripe * grainColor;
    }
        
    void On_TextureGenerate ()
    {
        int texWidth = 256;
        int texHeight = 256;
        
        Texture2D synthTexture = new Texture2D (texWidth, texHeight);
        
        for (int  i = 0; i < texWidth; i++)
        {
            for (int  j = 0; j < texHeight; j++)
            {
                float u = 1.0f * i / texWidth;
                float v = 1.0f * j / texHeight;
//                 Color col = stripes (u, v);
//                 Color col = noise (u, v);
                Color col = wood (u, v);
                synthTexture.SetPixel (i, j, col);
            }
        }
        
        synthTexture.Apply ();
        
        GetComponent <Renderer> ().materials[0].SetTexture ("_MainTex", synthTexture);
        
        GetComponent <Renderer> ().materials[0].SetTexture ("_BumpMap", synthTexture);
        GetComponent <Renderer> ().materials[0].EnableKeyword ("_NORMALMAP");
        
    }

    // Use this for initialization
    void Start () {
      On_TextureGenerate ();      
    }
    
    // Update is called once per frame
    void Update () {
            
    }
}
