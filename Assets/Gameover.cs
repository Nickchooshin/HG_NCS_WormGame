using UnityEngine;
using System.Collections;

public class Gameover : MonoBehaviour {
	void Start() {
		Screen.lockCursor = false;
	}

	void OnGUI() {
		if (GUI.Button (new Rect (Screen.width * 0.5f, Screen.height * 0.4f, Screen.width * 0.2f, Screen.height * 0.1f), "Restart")) {
			Application.LoadLevel (1);
		}
		if (GUI.Button (new Rect (Screen.width * 0.5f, Screen.height * 0.6f, Screen.width * 0.2f, Screen.height * 0.1f), "Title")) {
			Application.LoadLevel (0) ;
		}
	}
}
