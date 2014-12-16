using UnityEngine;
using System.Collections;

public class killMeOverTime : MonoBehaviour {

	public float lifeTime = 1.0f ;

	void Update () {
		Destroy (gameObject, lifeTime);
	}
}
