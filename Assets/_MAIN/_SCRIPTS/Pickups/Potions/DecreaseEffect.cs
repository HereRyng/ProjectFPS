using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaseEffect : Pickup
{
    [SerializeField] private Vector3 effectIncrease = new Vector3(5, 5);
    public override void Do()
    {     
        _owner.transform.localScale = effectIncrease;
    }
}
