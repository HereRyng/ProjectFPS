using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private HealthController healthController;
    [SerializeField] private StatsCharacterManager statsManager;
    [SerializeField] private SwitchWeapon _switchWeapon;

    [SerializeField] private HealthBar healthBar;
 
    private int _currentWeapon;
    public int CurrentWeapon => _currentWeapon;
    public float SpeedModified { get; set; }
    public float CurrentSpeed { get; private set; }

    public SwitchWeapon SwitchWeapon => _switchWeapon;

    private MoveCommand _moveCommand;
    public static event Action OnGameOver;

    private void Start()
    {
        _switchWeapon = GetComponentInChildren<SwitchWeapon>();
        healthController = GetComponent<HealthController>();
        CurrentSpeed = statsManager.Stats.Speed;
        healthBar.Initialize(statsManager.Stats.MaxHealth, statsManager.Stats.MaxHealth);
    }

    public void Update()
    {
        //print(CurrentSpeed + "C");
        //Debug.Log($"LIFE PLAYER: {healthController.GetHealth()}");
        if (healthController.GetHealth() <= 0)
        {
            OnGameOver?.Invoke();
        }

    }
    public void ChangeWeapon(int index)
    {
        _switchWeapon.Switch(index);
        _currentWeapon = index;

        if (_currentWeapon != index) 
            _currentWeapon = index;
    }
    public void Shoot()
    {
        _switchWeapon.Weapons[_currentWeapon].Shoot();
    }
    public void Move(Vector3 dir)
    {
        _moveCommand = new MoveCommand(transform, CurrentSpeed + SpeedModified, dir);
        GameManager.instance.AddCommand(_moveCommand);
    }

   public void Grab(Collider other)
    {
        Debug.Log("AGARRO EL PICKUP");
        Pickup potionGrab = other.GetComponent<Pickup>();
        potionGrab.SetOwner(this);
        potionGrab.Interaction();
        Destroy(potionGrab.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {             
            Grab(other);
        }
    }
}
