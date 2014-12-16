using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Boss : MonoBehaviour {

	public Transform LookAtTarget ;
	public Transform bullitPrefab ;
	public int Life = 100 ;

    private ShootPattern[] shootPatternList;

	private int patternState = 0 ;
	public float cooldown = 3.5f ;

	int bullitType = 0 ;

	// Use this for initialization
	void Start () {
        shootPatternList = gameObject.GetComponents<ShootPattern>();

        StartCoroutine("ShootDelay");
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

    IEnumerator ShootDelay()
    {
        ShootPattern shootPattern;

        yield return new WaitForSeconds(cooldown);

        while (true)
        {
            patternState = Random.Range(0, shootPatternList.Length);
            shootPattern = shootPatternList[patternState];

            shootPattern.StartCoroutine("Shoot");

            yield return new WaitForSeconds(shootPattern.GetCooldown());

            shootPattern.StopCoroutine("Shoot");

            yield return new WaitForSeconds(cooldown);
        }
    }
}
