using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ReturnToStartScene : MonoBehaviour {

	void Start () {

	}

	void Update () {

	}

	public void On_MenuButton ()
	{
		SceneManager.LoadScene ("StartScreen");  
	}

}


