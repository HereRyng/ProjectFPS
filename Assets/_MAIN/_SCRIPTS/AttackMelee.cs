using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMelee : MonoBehaviour
{
    [SerializeField] private LayerMask _hittableDamageMask;
    [SerializeField] private EnemyMelee enemyMelee;
    public IDamageable Objetive { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if ((_hittableDamageMask & 1 << other.gameObject.layer) != 0)
        {
            Objetive = other.GetComponent<IDamageable>();
            var stats = (CharacterHurtStats)enemyMelee.StatsManager.Stats;
            Objetive.TakeDamage(stats.DamagePush);
        }
    }
}
