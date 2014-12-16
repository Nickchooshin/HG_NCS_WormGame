using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	public float mouseRotate = 5.0f ;

	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update () {
		float fRotation = Input.GetAxis ("Mouse X") * mouseRotate;
		transform.Rotate (0, fRotation, 0);
	}
}
