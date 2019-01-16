using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

using System.IO;
using System;

[ExecuteInEditMode]
public class ShowCredits : MonoBehaviour {

	void updateCredits ()
	{
		string creditsFilename = SceneManager.GetActiveScene ().path;
		if ((creditsFilename == null) || (creditsFilename == "")) {
			return;
		}
		creditsFilename = Path.GetDirectoryName (Path.GetDirectoryName (creditsFilename)) + Path.DirectorySeparatorChar + "Credits.txt";

		try
		{
		string message = "";
		StreamReader r = new StreamReader (creditsFilename);
		message += r.ReadToEnd ();
		r.Close ();

		GameObject text = GameObject.Find ("Credits");
		TextMesh tm;
		if (text == null) {
			text = new GameObject ();
			text.name = "Credits";
			tm = text.AddComponent <TextMesh> ();
		} else {
			tm = text.GetComponent <TextMesh> ();
		}
		text.transform.parent = this.gameObject.transform;
		text.transform.localPosition = new Vector3 (-2.5f, 1.3f, 2.5f);
		text.transform.localScale = new Vector3 (0.05f, 0.05f, 0.05f);
		tm.text = message;
		tm.color = new Color (0.01f, 0.01f, 0.01f);
		}
		catch (Exception e) {
		}
	}

	void Update () {
		updateCredits ();
	}
	
}
