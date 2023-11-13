using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text ammoText;
    private float currentAmmo;
    [SerializeField] private SwitchWeapon weapon;

    private void Update()
    {
        ammoText.text = currentAmmo.ToString();
        GetCurrentAmmoWeapon();
    }

    public void GetCurrentAmmoWeapon()
    {
        currentAmmo = weapon.Weapons[weapon.SelectionWeapon].CurrentAmmo;
    }


}
