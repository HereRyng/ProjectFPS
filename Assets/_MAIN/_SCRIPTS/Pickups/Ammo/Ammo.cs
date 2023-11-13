using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : Pickup
{
    [SerializeField] private int ammunitionToAdd;
    public static Action<int> OnAddAmmo;

    public override void Do()
    {
        OnAddAmmo?.Invoke(ammunitionToAdd);
    }

}
