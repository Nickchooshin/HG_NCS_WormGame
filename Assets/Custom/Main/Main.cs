using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
	void OnGUI() {
		if (GUI.Button (new Rect (Screen.width * 0.5f, Screen.height * 0.4f, Screen.width * 0.2f, Screen.height * 0.1f), "Start")) {
			Application.LoadLevel (1);
		}
		if (GUI.Button (new Rect (Screen.width * 0.5f, Screen.height * 0.6f, Screen.width * 0.2f, Screen.height * 0.1f), "Exit")) {
			Application.Quit() ;
		}
	}
}
