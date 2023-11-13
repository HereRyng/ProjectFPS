using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenomEffect : Pickup
{
    private bool applyVenom;
    [SerializeField] private float effectVenom = 0.5f;
    public override void Do()
    {
        applyVenom = true;
    }
    public override void Update()
    {
        //if (applyVenom && owner != null) 
        //    owner.TakeDamage(effectVenom);

    }
}
