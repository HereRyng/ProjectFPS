using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : EnemyController
{
    [SerializeField] private Gun fireArm;
    [SerializeField] private Transform target;
    public static Action OnDieBoss;

    public override void Start()
    {
        base.Start();

    }
    public override void Update()
    {
       
        base.Update();
        Attack();
        Move();
    }


    public override void Attack()
    {
        if (currentCooldownAttack >= cooldownAttack)
        {
            currentCooldownAttack = 0;
            fireArm.Shoot();
        }
    }
    public override void Move()
    {
        var dir = (target.transform.position - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(dir);
        transform.position = Vector3.MoveTowards(transform.position, target.position, statsManager.Stats.Speed * Time.deltaTime);
    }

    public override void Die()
    {
        if (healthController.GetHealth() <= 0)
        {
            OnDieBoss?.Invoke();
        }
    }
}
