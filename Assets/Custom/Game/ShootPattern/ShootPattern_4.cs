using UnityEngine;
using System.Collections;

public class ShootPattern_4 : ShootPattern {

	public ShootPattern_4() : base(7.5f, 0.1f)
    {
    }

    public override IEnumerator Shoot()
    {
        while (true)
        {
            Vector3[] direction = new Vector3[4];

            transform.Rotate(0, m_iBullitType * 6.0f, 0);

            direction[0] = transform.forward;
            direction[1] = transform.right;
            direction[2] = -transform.forward;
            direction[3] = -transform.right;

            transform.rotation = Quaternion.Euler(0, 0, 180.0f);

            m_iBullitType = m_iBullitType % 15 + 1;

            for (int i = 0; i < 4; i++)
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
