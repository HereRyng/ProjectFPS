using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class EnemyController : MonoBehaviour
{
    ///----------------<PARAMETERS_TO_ATTACK>--------------------------/// 
  

    ///----------------<TIMER>--------------------------/// 
    protected float currentCooldownAttack;
    [SerializeField] protected float cooldownAttack;
    ///----------------<TIMER>--------------------------/// 

    protected HealthController healthController;
    protected Animator anim;
    [SerializeField] protected HealthBar healthBar;
    protected Vector3 direction;

    public StatsCharacterManager StatsManager => statsManager;
    [SerializeField] protected StatsCharacterManager statsManager;
    public float CurrentSpeed { get; private set; }

    public static event Action OnDeath;


    public virtual void Start()
    {
        currentCooldownAttack = 0;
        CurrentSpeed = statsManager.Stats.Speed;
        healthController = GetComponent<HealthController>();
        anim = GetComponent<Animator>();
        healthBar.Initialize(statsManager.Stats.MaxHealth, statsManager.Stats.MaxHealth);
    }
    public virtual void Update()
    {
      
        currentCooldownAttack += Time.deltaTime;
        HandleAnimations();
        Die();

    }

    public bool IsMoving
    {
        get
        {
            return direction.x != 0 || direction.z != 0;
        }
    }
    public bool IsAttack
    {
        get
        {
            return direction.x != 0 || direction.z != 0;
        }
    }
    public void HandleAnimations()
    {
        if (IsMoving)
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }

    }
    public virtual void Attack()
    {
        anim.SetTrigger("Attack");
    }
   
    public virtual void Move()
    {
      
    }
    public virtual void Die()
    {
        if (healthController.GetHealth() <= 0)
        {
            OnDeath?.Invoke();
            //anim.SetBool("Dead", true); //TODO: ANIMACION
            Destroy(gameObject);
           
        }
     
    }
    private void OnDestroy()
    {
        
    }



}
