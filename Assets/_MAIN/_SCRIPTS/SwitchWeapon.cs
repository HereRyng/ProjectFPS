using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    private int selectionWeapon;
    [SerializeField]
    private List<Gun> weapons;
    public List<Gun> Weapons { get => weapons; private set => weapons = value; }
    public int SelectionWeapon => selectionWeapon;

    void Start()
    {
        //TODO: REVISAR DESPUES
        var weapon = GetComponentsInChildren<Gun>();

        for (int i = 0; i < weapon.Length; i++)
        {
            weapons.Add(weapon[i]);           
        }
    }

    void Update()
    {
        foreach (Gun weaponPrefabs in weapons)
        {
            weaponPrefabs.gameObject.SetActive(false);
        }
        transform.GetChild(SelectionWeapon).gameObject.SetActive(true);
    }

    public void Switch(int weapon)
    {
        selectionWeapon = weapon;
    }
}
