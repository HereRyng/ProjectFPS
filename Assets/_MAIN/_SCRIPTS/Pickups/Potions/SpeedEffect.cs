using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedEffect : Pickup
{    
    [SerializeField] private float effectSpeed = 20f;  
    public override void Do()
    {      
        //Instantiate(effectPrefab, positionEffectRespawn);
        _owner.SpeedModified = effectSpeed;
    }

    public override void Update()
    {
        //if (owner.SpeedModified == effectSpeed) 
        //cooldownNow += Time.deltaTime;
        //if (cooldownNow >= 3f)
        //{
        //    owner.SpeedModified = 0;
        //    Destroy(gameObject);
        //    Filled = false;
        //}
    }
}
