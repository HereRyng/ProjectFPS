using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{
    public override void Start()
    {
        base.Start();
    }
    public override void Update()
    {
        base.Update();
    }
    public override void Shoot()
    {
        if (CurrentAmmo >= 1)
        {
            Bullet bullet = Instantiate(_stats.BulletPrefab, bulletPointSpawn.transform.position, Quaternion.LookRotation(bulletPointSpawn.transform.forward));
            bullet.GetComponent<Bullet>().SetOwner(this);
            CurrentAmmo--;
        }  
    }
    public override void AddAmmo(int ammo)
    {
        base.AddAmmo(ammo);
    }


}
