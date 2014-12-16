using UnityEngine;
using System.Collections;

public class ShootPattern_3 : ShootPattern {

    public ShootPattern_3() : base(5.0f, 0.25f)
    {
    }

    public override IEnumerator Shoot()
    {
        while (true)
        {
            Vector3[] direction = new Vector3[8];

            transform.LookAt(LookAtTarget);

            direction[0] = transform.forward;
            direction[1] = transform.right;
            direction[2] = -transform.forward;
            direction[3] = -transform.right;

            transform.Rotate(0, 45, 0);
            direction[4] = transform.forward;
            direction[5] = transform.right;
            direction[6] = -transform.forward;
            direction[7] = -transform.right;

            transform.rotation = Quaternion.Euler(0, 0, 180.0f);

            for (int i = 0; i < 8; i++)
            {
                GameObject bullit = Instantiate(bullitPrefab.gameObject, transform.position, Quaternion.identity) as GameObject;

                bullit.transform.position += direction[i];
                bullit.gameObject.tag = "enemyProjectile";
                bullit.rigidbody.AddForce(direction[i] * 1000);
            }

            yield return new WaitForSeconds(m_fShootCooldown);
        }
    }
}
