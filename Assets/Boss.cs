using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

	public Transform LookAtTarget ;
	public Transform bullitPrefab ;
	public int Life = 100 ;

	int patternState = 0 ;
	public float cooldown = 3.5f ;
	float currentTime ;
	float shootCooldown = 0.0f ;
	float shootCurrentTime ;

	int bullitType = 0 ;

	// Use this for initialization
	void Start () {
		currentTime = Time.time;
	}

	void OnGUI() {
		GUI.Box (new Rect (Screen.width * 0.01f, Screen.height * 0.01f, Screen.width * 0.2f, Screen.height * 0.05f), "Boss Life : " + Life);
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "wormProjectile") {
			--Life ;

			Destroy(col.gameObject) ;

			if(Life<=0)
				Application.LoadLevel(3) ;
		}
	}
	
	// Update is called once per frame
	void Update () {
		float fTime = Time.time - currentTime;

		if (fTime >= cooldown) {
			if(patternState!=0)
				patternState = 0 ;
			else
				patternState = Random.Range(1, 5);

			switch(patternState)
			{
			case 0 :
				cooldown = 3.5f ;
				break ;

			case 1 :
				cooldown = 10.0f ;
				shootCooldown = 0.1f ;
				break ;

			case 2 :
				cooldown = 10.0f ;
				shootCooldown = 0.5f ;
				break ;

			case 3 :
				cooldown = 5.0f ;
				shootCooldown = 0.25f ;
				break ;

			case 4 :
				cooldown = 7.5f ;
				shootCooldown = 0.1f ;
				break ;
			}

			bullitType = 0 ;
			currentTime = Time.time ;
			shootCurrentTime = Time.time ;
		}

		Shoot();
	}

	void Shoot() {
		float fTime = Time.time - shootCurrentTime;

		if (fTime >= shootCooldown) {
			switch(patternState)
			{
			case 1 :
				ShootType1() ;
				break ;

			case 2 :
				ShootType2() ;
				break ;

			case 3 :
				ShootType3() ;
				break ;

			case 4 :
				ShootType4() ;
				break ;
			}

			shootCurrentTime = Time.time ;
		}
	}

	void ShootType1() {
		Vector3 direction;
		direction = LookAtTarget.position - transform.position;
		direction = direction / direction.magnitude;
		
		GameObject bullit = Instantiate (bullitPrefab.gameObject, transform.position, Quaternion.identity) as GameObject;
		
		bullit.transform.position += direction;
		bullit.gameObject.tag = "enemyProjectile";
		bullit.rigidbody.AddForce (direction * 1000);
	}

	void ShootType2() {
		Vector3[] direction = new Vector3[4];

		if (bullitType == 1)
			transform.Rotate (0, 45, 0);

		direction [0] = transform.forward;
		direction [1] = transform.right;
		direction [2] = -transform.forward;
		direction [3] = -transform.right;

		if (bullitType == 1)
			transform.Rotate (0, -45, 0);

		bullitType = bullitType % 2 + 1;

		for (int i=0; i<4; i++) {
			GameObject bullit = Instantiate (bullitPrefab.gameObject, transform.position, Quaternion.identity) as GameObject;
			
			bullit.transform.position += direction[i] ;
			bullit.gameObject.tag = "enemyProjectile";
			bullit.rigidbody.AddForce (direction[i] * 2000);
		}
	}

	void ShootType3() {
		Vector3[] direction = new Vector3[8];

		transform.LookAt (LookAtTarget);

		direction [0] = transform.forward;
		direction [1] = transform.right;
		direction [2] = -transform.forward;
		direction [3] = -transform.right;

		transform.Rotate (0, 45, 0);
		direction [4] = transform.forward;
		direction [5] = transform.right;
		direction [6] = -transform.forward;
		direction [7] = -transform.right;

		transform.rotation = Quaternion.Euler (0, 0, 180.0f);

		for (int i=0; i<8; i++) {
			GameObject bullit = Instantiate (bullitPrefab.gameObject, transform.position, Quaternion.identity) as GameObject;
			
			bullit.transform.position += direction[i] ;
			bullit.gameObject.tag = "enemyProjectile";
			bullit.rigidbody.AddForce (direction[i] * 1000);
		}
	}

	void ShootType4() {
		Vector3[] direction = new Vector3[4];

		transform.Rotate (0, bullitType * 6.0f, 0);

		direction [0] = transform.forward;
		direction [1] = transform.right;
		direction [2] = -transform.forward;
		direction [3] = -transform.right;

		transform.rotation = Quaternion.Euler (0, 0, 180.0f);
		
		bullitType = bullitType % 15 + 1;

		for (int i=0; i<4; i++) {
			GameObject bullit = Instantiate (bullitPrefab.gameObject, transform.position, Quaternion.identity) as GameObject;
			
			bullit.transform.position += direction[i] ;
			bullit.gameObject.tag = "enemyProjectile";
			bullit.rigidbody.AddForce (direction[i] * 1000);
		}
	}
}
