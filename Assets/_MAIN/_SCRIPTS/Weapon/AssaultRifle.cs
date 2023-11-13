using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : Gun
{
   
    public override void Update()
    {
        base.Update();
    }
    public override void Shoot()
    {
      
        if (CurrentAmmo >= 1)
        {       
            for (int i = 0; i < 3; i++)
            {
                Bullet bullet = Instantiate(_stats.BulletPrefab, bulletPointSpawn.transform.position + bulletPointSpawn.transform.forward * i / 1.5f, Quaternion.LookRotation(bulletPointSpawn.transform.forward));
                bullet.GetComponent<Bullet>().SetOwner(this);
                CurrentAmmo--;
            }
        }
       
    }
    public override void AddAmmo(int ammo)
    {
        base.AddAmmo(ammo);
    }
}
