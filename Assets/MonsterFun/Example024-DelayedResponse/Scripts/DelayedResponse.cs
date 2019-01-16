using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedResponse : MonoBehaviour {

        public float delayTime = 5.0f;
        
        private bool coRoutineRunning = false;
        
	// Use this for initialization
	void Start () {
		
	}
	
	IEnumerator DelayAndChange (float delayPeriod)
	{
	  if (!coRoutineRunning)
	  {
            coRoutineRunning = true;
            yield return new WaitForSeconds (delayPeriod);
            Color oldColour = this.GetComponent <MeshRenderer> ().materials[0].color;
            this.GetComponent <MeshRenderer> ().materials[0].color = new Color (1, 0, 1);
            yield return new WaitForSeconds (0.5f);
            this.GetComponent <MeshRenderer> ().materials[0].color = oldColour;          
            coRoutineRunning = false;
          }
	}
	
	// Update is called once per frame
	void Update () {
           if (Input.GetAxis ("Fire1") > 0)
           {
             StartCoroutine (DelayAndChange (delayTime));
           }
	}
}
