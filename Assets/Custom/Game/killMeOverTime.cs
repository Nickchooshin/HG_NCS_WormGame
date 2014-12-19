using UnityEngine;
using System.Collections;

public class killMeOverTime : MonoBehaviour {

	public float lifeTime = 1.0f ;

	void Update () {
		Destroy (gameObject, lifeTime);
	}

    void OnCollisionEnter(Collision col)
    {
        if( (gameObject.tag=="wormProjectile" && col.gameObject.tag=="enemyProjectile") ||
            (gameObject.tag=="enemyProjectile" && col.gameObject.tag=="wormProjectile") )
            Destroy(gameObject);
    }
}
