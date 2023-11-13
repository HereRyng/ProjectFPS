using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GunStats", menuName = "Stats/Gun", order = 0)]
public class GunStats : ScriptableObject
{
    public Bullet BulletPrefab => _bulletPrefab;
    [SerializeField] private Bullet _bulletPrefab;
    public int Damage => damage;
    [SerializeField] private int damage;

    public int Cooldown => cooldown;
    [SerializeField] private int cooldown;

    public int MaxAmmo => maxAmmo;
    [SerializeField] private int maxAmmo;

}
