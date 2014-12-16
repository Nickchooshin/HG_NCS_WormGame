using UnityEngine;
using System.Collections;

public class TurretControl : MonoBehaviour {

	public Transform LookAtTarget ;
	public float damp = 6.0f ;
	public Transform bullitPrefab ;
	private int savedTime ;

	void Update () {
		if (LookAtTarget) {
			Quaternion rotate = Quaternion.LookRotation(LookAtTarget.position - transform.position) ;

			transform.rotation = Quaternion.Slerp (transform.rotation, rotate, Time.deltaTime * damp) ;

			int seconds = (int)Time.time ;
			int oddeven = (seconds % 2) ;

			if(oddeven!=0) {
				Shoot(seconds) ;
			}
		}
		//transform.LookAt (LookAtTarget);
	}

	void Shoot(int seconds)
	{
		if (seconds != savedTime) {
			GameObject bullit = Instantiate (bullitPrefab.gameObject, transform.Find ("spawnPoint").transform.position, Quaternion.identity) as GameObject;

			bullit.gameObject.tag = "enemyProjectile" ;
			bullit.rigidbody.AddForce (transform.forward * 1000);

			savedTime = seconds ;
		}
	}
}