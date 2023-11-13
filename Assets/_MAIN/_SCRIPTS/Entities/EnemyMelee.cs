using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : EnemyFollowBase
{

    public override void Start()
    {
        base.Start();

    }
    public override void Update()
    {
        base.Update();
        Move();
        if (!IsMoving &&distanceToTarget <= rangeAttack)
            Attack();

    }
    public override void Attack()
    {
        base.Attack();
    }
}
