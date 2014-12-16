using UnityEngine;
using System.Collections;

public class MoveAround : MonoBehaviour {

	// Moving around
	public float speed = 3.0f ;
	public float rotateSpeed = 3.0f ;

	// Shooting
	public Transform bullitPrefab ;

	// Dying
	private bool dead = false ;

	// Getting hit
	public float tumbleSpeed = 800.0f ;
	public float decreaseTime = 0.01f ;
	public float decayTime = 0.01f ;
	public static bool gotHit = false ;
	private float[] backup = {800.0f, 0.01f, 0.01f} ;

	void Start() {
		HealthControl.LIVES = 3;
	}

	void Update () {
		CharacterController controller = GetComponent<CharacterController> ();

		float fForward = Input.GetAxis ("Vertical");
		float fSide = Input.GetAxis ("Horizontal");

		Vector3 forward = transform.TransformDirection(Vector3.forward) * fForward * speed;
		Vector3 side = transform.TransformDirection(Vector3.right) * fSide * speed;

		controller.SimpleMove (forward + side);

		if(Input.GetMouseButtonDown(0))
		{
			GameObject bullit = Instantiate(bullitPrefab.gameObject, GameObject.Find("WspawnPoint").transform.position, Quaternion.identity) as GameObject;
			bullit.gameObject.tag = "wormProjectile" ;
			bullit.rigidbody.AddForce(transform.forward * 2000) ;
		}
	}

	/*void OnControllerColliderHit(ControllerColliderHit hit) {
		if (hit.gameObject.tag == "fallout") {
			dead = true ;

			HealthControl.LIVES -= 1 ;
		}

		if (hit.gameObject.tag == "enemyProjectile") {
			//gotHit = true ;
			HealthControl.LIVES -= 1 ;

			Destroy(hit.gameObject) ;
		}

		if (HealthControl.LIVES == 0) {
			Application.LoadLevel(2) ;
		}
	}*/

	void OnCollisionEnter(Collision hit)
	{
		if (hit.gameObject.tag == "fallout") {
			dead = true ;
			
			HealthControl.LIVES -= 1 ;
		}
		
		if (hit.gameObject.tag == "enemyProjectile") {
			//gotHit = true ;
			HealthControl.LIVES -= 1 ;
			
			Destroy(hit.gameObject) ;
		}
		
		if (HealthControl.LIVES == 0) {
			Application.LoadLevel(2) ;
		}
	}

	void LateUpdate() {
		if (dead) {
			transform.position = new Vector3(0, 4, 0) ;
			GameObject.Find("Main Camera").transform.position = new Vector3(0, 4, -10) ;
			dead = false ;
		}

		/*if (gotHit) {
			if(tumbleSpeed < 1)
			{
				tumbleSpeed = backup[0] ;
				decreaseTime = backup[1] ;
				decayTime = backup[2] ;
				gotHit = false ;
			}
			else{
				transform.Rotate(0, tumbleSpeed * Time.deltaTime, 0, Space.World) ;
				tumbleSpeed = tumbleSpeed - decreaseTime ;
				decreaseTime += decayTime ;
			}
		}*/
	}
}
