using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MakeMessageBoard : NetworkBehaviour {
  public GameObject messageBoardPrefab;

  void Start ()
  {
    if (isServer)
    {
      GameObject board = Instantiate (messageBoardPrefab);
      NetworkServer.Spawn (board);
    }
  }

}
