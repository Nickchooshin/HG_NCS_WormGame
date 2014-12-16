using UnityEngine;
using System.Collections;

public class ShootPattern_1 : ShootPattern {

    public ShootPattern_1() : base(10.0f, 0.1f)
    {
    }

    public override IEnumerator Shoot()
    {
        while (true)
        {
            Vector3 direction;
            direction = LookAtTarget.position - transform.position;
            direction = direction / direction.magnitude;

            GameObject bullit = Instantiate(bullitPrefab.gameObject, transform.position, Quaternion.identity) as GameObject;

            bullit.transform.position += direction;
            bullit.gameObject.tag = "enemyProjectile";
            bullit.rigidbody.AddForce(direction * 1000);

            yield return new WaitForSeconds(m_fShootCooldown);
        }
    }
}
