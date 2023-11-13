using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGun
{
    GunStats Stats { get; }
    void Shoot();
    void AddAmmo(int ammo);
}
