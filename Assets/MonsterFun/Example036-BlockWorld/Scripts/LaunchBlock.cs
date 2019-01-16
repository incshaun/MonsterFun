using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LaunchBlock : NetworkBehaviour {

        public GameObject blockPrefab;

        public float turnSpeed = 10.0f;
        
        public float launchForce = 5.0f;
        
        public float fireInterval = 0.5f;
        
        private float timeTillNextFire = 0.0f;

        // Give each player their own colour.
        private Color blockColour;
        
	// Use this for initialization
	void Start () {
          blockColour = new Color (Random.Range (0.0f, 1.0f), Random.Range (0.0f, 1.0f), Random.Range (0.0f, 1.0f));
	}
	
	[Command]
	void CmdSpawn ()
	{
          GameObject block = Instantiate (blockPrefab, transform.position + transform.forward, Quaternion.identity);
          block.GetComponent <Rigidbody> ().AddForce (launchForce * (transform.forward + transform.up), ForceMode.Impulse);
          block.GetComponent <MeshRenderer> ().material.color = blockColour;
          NetworkServer.Spawn (block);
	}
	
	// Update is called once per frame
	void Update () {
	  if (isLocalPlayer)
	  {
            float hori = Input.GetAxis ("Horizontal");
            float fire = Input.GetAxis ("Fire1");
            
            transform.rotation *= Quaternion.AngleAxis (hori * turnSpeed * Time.deltaTime, transform.up);
            if ((timeTillNextFire < 0.0f) && (fire > 0.5f))
            {
              CmdSpawn ();
              timeTillNextFire = fireInterval;
            }
            timeTillNextFire -= Time.deltaTime;
          }
	}
}
