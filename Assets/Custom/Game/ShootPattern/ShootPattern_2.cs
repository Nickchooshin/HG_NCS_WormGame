using UnityEngine;
using System.Collections;

public class ShootPattern_2 : ShootPattern {

    public ShootPattern_2() : base(10.0f, 0.5f)
    {
    }

    public override IEnumerator Shoot()
    {
        while (true)
        {
            Vector3[] direction = new Vector3[4];

            if (m_iBullitType == 1)
                transform.Rotate(0, 45, 0);

            direction[0] = transform.forward;
            direction[1] = transform.right;
            direction[2] = -transform.forward;
            direction[3] = -transform.right;

            if (m_iBullitType == 1)
                transform.Rotate(0, -45, 0);

            m_iBullitType = m_iBullitType % 2 + 1;

            for (int i = 0; i < 4; i++)
            {
                GameObject bullit = Instantiate(bullitPrefab.gameObject, transform.position, Quaternion.identity) as GameObject;

                bullit.transform.position += direction[i];
                bullit.gameObject.tag = "enemyProjectile";
                bullit.rigidbody.AddForce(direction[i] * 2000);
            }

            yield return new WaitForSeconds(m_fShootCooldown);
        }
    }
}
