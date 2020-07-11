using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    public override void Fire()
    {
        if (weaponCooldown < 1)
        {
            CreateBullet();
            weaponCooldown = weaponRate;
        }
    }
}
