using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTracker : MonoBehaviour {

        // Number of coins to generate.
        public int NumberOfCoins = 10;
        
        // Size of area to scatter them.
        public float radius = 10.0f;
        
        // Template for a coin.
        public GameObject coinPrefab;
        
        // Internal list to keep track of coins.
        private List<GameObject> coinList;
        
	// Use this for initialization
	void Start () {
	  // Create the coin list.
	  coinList = new List<GameObject> ();
	  
	  // Instantiate some coins when the application starts.
	  for (int i = 0; i < NumberOfCoins; i++)
	  {
	    GameObject coin = Instantiate (coinPrefab, 
	      new Vector3 (Random.Range (-radius, radius), 0.6f, Random.Range (-radius, radius)),
	      Quaternion.AngleAxis (90, new Vector3 (1,0,0)));
            coin.GetComponent <CoinActivity> ().manager = this;
            coinList.Add (coin);
	  }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void registerCoinCollect (GameObject coin)
	{
          print ("Trigger Manager");
          coinList.Remove (coin);
          Destroy (coin);
          
          if (coinList.Count == 0)
          {
            print ("Yay. All coins have been collected.");
          }
        }
}
