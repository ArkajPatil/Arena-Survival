using UnityEngine;
using System;

public class EnemyHealth : MonoBehaviour, IDamageable
{

    [SerializeField] private EnemyData enemyData;

    private float currentHealth;
    private bool bDead = false;

    public event Action OnEnemyDeath;
    public static event Action OnEnemyDeathStaticEvent;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = enemyData.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0 && !bDead)
        {
            bDead = true;
            Die();
        } 
    }

    void Die()
    {
        OnEnemyDeath?.Invoke();
        OnEnemyDeathStaticEvent?.Invoke();
    }
}
