using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField]
    protected GameObject bulletType = null;

    protected float weaponCooldown = 0;

    [SerializeField]
    protected float weaponRate = 0;

    [SerializeField]
    protected float spray = 0;

    public abstract void Fire();

    private void Update()
    {
        weaponCooldown = Mathf.Max(weaponCooldown - 1, 0);
    }

    protected void CreateBullet()
    {
        GameObject bullet = Instantiate(bulletType, transform.position, transform.rotation);
        bullet.GetComponent<Bullet>().Initialise(transform.eulerAngles.z + Random.Range(-spray, spray));
    }
}
