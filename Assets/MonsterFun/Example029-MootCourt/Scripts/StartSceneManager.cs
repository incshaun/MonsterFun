using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartSceneManager : MonoBehaviour {

	void Start () {

	}

	void Update () {

	}

	public void On_Lawyer ()
	{
		Global.selectedRole = "Lawyer";
		SceneManager.LoadScene ("MootCourt");  
	}

	public void On_Judge ()
	{
		Global.selectedRole = "Judge";
		SceneManager.LoadScene ("MootCourt");  
	}

	public void On_Spectator ()
	{
		Global.selectedRole = "Spectator";
		SceneManager.LoadScene ("MootCourt");  
	}

}
