using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : EnemyFollowBase
{
    [SerializeField] private Gun fireArm;

    public override void Start()
    {
        base.Start();

    }
    public override void Update()
    {
        
        base.Update();
        Move();

        if (chasing)
        {
            Attack();
        }
    }
   
    
    public override void Attack()
    {
        if (currentCooldownAttack >= cooldownAttack)
        {
            currentCooldownAttack = 0;
            fireArm.Shoot();
        }  
    }


}
