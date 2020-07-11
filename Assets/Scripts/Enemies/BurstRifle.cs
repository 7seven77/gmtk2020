using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstRifle : Weapon
{
    private int bulletNumber = 2;

    private float lowestSpray;
    private void Start()
    {
        lowestSpray = spray;
    }
    public override void Fire()
    {
        if (weaponCooldown < 1)
        {
            CreateBullet();
            if (bulletNumber > 0)
            {
                weaponCooldown = 20;
                bulletNumber--;
                spray *= 1.2f;
                return;
            }
            weaponCooldown = weaponRate;
            bulletNumber = 2;
            spray = lowestSpray;
        }
    }
}
