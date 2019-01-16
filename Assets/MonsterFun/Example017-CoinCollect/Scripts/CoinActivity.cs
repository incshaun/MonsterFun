using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinActivity : MonoBehaviour {

        public CoinTracker manager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
            this.transform.rotation *= Quaternion.AngleAxis (1.0f, new Vector3 (0,0,1));
	}
	
	void OnTriggerEnter(Collider other) {
          if (manager != null)
          {
            manager.registerCoinCollect (this.gameObject);
          }
        }
	
}
