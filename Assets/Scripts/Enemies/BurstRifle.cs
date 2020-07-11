using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstRifle : Weapon
{
    [SerializeField]
    private int extraShots = 1;

    private int bulletNumber;

    private float lowestSpray;
    private void Start()
    {
        lowestSpray = spray;
        bulletNumber = extraShots;
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
            bulletNumber = extraShots;
            spray = lowestSpray;
        }
    }
}
