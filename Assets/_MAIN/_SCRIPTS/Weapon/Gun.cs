using UnityEngine;

public abstract class Gun : MonoBehaviour, IGun
{
    public GunStats Stats => _stats;

    public float CurrentAmmo { get; protected set; }

    public float maxAmmo => _stats.MaxAmmo;

    [SerializeField] protected GunStats _stats;
    [SerializeField] protected GameObject bulletPointSpawn;

  
    public virtual void Start()
    {
        Ammo.OnAddAmmo += AddAmmo;
        CurrentAmmo = maxAmmo;

    }
    private void OnDestroy()
    {
        Ammo.OnAddAmmo -= AddAmmo;
    }
    public virtual void Shoot()
    {     
        CurrentAmmo--;
    }
    public virtual void Update()
    {
       
    }
    public virtual void AddAmmo(int ammo)
    {
        CurrentAmmo += ammo;
        if (CurrentAmmo >= maxAmmo)
        {
            CurrentAmmo = maxAmmo;
        }
    }



}
