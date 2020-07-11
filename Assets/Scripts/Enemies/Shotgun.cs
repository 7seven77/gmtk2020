using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{

    public override void Fire()
    {
        if (weaponCooldown < 1)
        {
            for (int i = 0; i < 3; i++)
            {
                CreateBullet();
            }
            weaponCooldown = weaponRate;
        }
    }
}
