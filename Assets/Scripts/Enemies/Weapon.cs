using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletType = null;

    private float weaponCooldown = 0;

    [SerializeField]
    private float weaponRate = 0;

    public void Fire()
    {
        if (weaponCooldown < 1)
        {
            GameObject bullet = Instantiate(bulletType, transform.position, transform.rotation);
            bullet.GetComponent<Bullet>().Initialise(transform.eulerAngles.z);
            weaponCooldown = weaponRate;
        }
    }

    private void Update()
    {
        weaponCooldown = Mathf.Max(weaponCooldown - 1, 0);
    }
}
