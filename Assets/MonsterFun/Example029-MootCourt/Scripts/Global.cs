using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Global : MonoBehaviour {
	public static string selectedRole;

	void Start () {
		SceneManager.sceneLoaded += On_LevelWasLoaded;
	}

	void Update () {

	}

	void Awake () {
		DontDestroyOnLoad (transform.gameObject);
	}


	void On_LevelWasLoaded (Scene scene, LoadSceneMode scenemode)
	{
		// any setup here that needs to occur once a level loads.
	}
}


