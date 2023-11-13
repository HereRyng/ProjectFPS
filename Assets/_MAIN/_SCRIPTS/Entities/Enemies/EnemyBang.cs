using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBang : EnemyFollowBase
{  
    private IDamageable objetive;
    [SerializeField] private LayerMask _hittableDamageMask;

    public override void Start()
    {
        base.Start();
    }
    public override void Update()
    {
        base.Update();
        Move();
       
    }
    public override void Attack()
    {
        var stats = (CharacterHurtStats)statsManager.Stats;
        objetive.TakeDamage(stats.DamagePush);
        Destroy(gameObject);
    }

    public void OnTriggerStay(Collider other)
    {
        if ((_hittableDamageMask & 1 << other.gameObject.layer) != 0)
        {
            Debug.Log($"Estoy chocando");
            objetive = other.GetComponent<IDamageable>();
            Attack();
        }

    }


   
}
