using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Observables;
using System;

public class HealthController : MonoBehaviour, IDamageable
{   
    private int currentHealth;
    private StatsCharacterManager statsManager;
   [SerializeField] private HealthBar healthBar;
    public static event Action OnDie;



    private void Awake()
    {
        
    }
    public void Start()
    {
        statsManager = GetComponent<StatsCharacterManager>();
        currentHealth = statsManager.Stats.MaxHealth;
    }


    void Update()
    {

    }
    public void TakeDamage(int damage)
    {
       
        healthBar.MyCurrentValue -= damage;
        currentHealth -= damage;
      

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();

        }
    }
    public int GetHealth()
    {
        return currentHealth;
    }
    public void Die()
    {  

    }



}
