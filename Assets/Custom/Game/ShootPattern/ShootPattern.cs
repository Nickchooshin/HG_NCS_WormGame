using UnityEngine;
using System.Collections;

public abstract class ShootPattern : MonoBehaviour {

    private static bool Init = false;
    protected static Transform LookAtTarget = null;
    protected static Transform bullitPrefab = null;

    protected readonly float m_fCooldown = 0.0f;
    protected readonly float m_fShootCooldown = 0.0f;
    protected int m_iBullitType = 0;

    public ShootPattern(float cooldown, float shootCooldown)
    {
        m_fCooldown = cooldown;
        m_fShootCooldown = shootCooldown;
    }

    void Start()
    {
        if (!Init)
        {
            ShootObjectManager shootObject = gameObject.GetComponent<ShootObjectManager>();
            LookAtTarget = shootObject.LookAtTarget;
            bullitPrefab = shootObject.bullitPrefab;

            Init = true;
        }
    }

    public float GetCooldown()
    {
        return m_fCooldown;
    }

    public abstract IEnumerator Shoot();
}
