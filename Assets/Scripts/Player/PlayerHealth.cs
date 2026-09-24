using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth = 100.0f;
    private float currentHealth;

    public event Action OnDeath;

    private bool bDead = false;

    public static event Action<float> OnPlayerHealthChange;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        OnPlayerHealthChange?.Invoke(currentHealth);

        if(currentHealth <= 0.0f && !bDead)
        {
            Die();
        }
    }

    private void Die()
    {
        // game over logic
        bDead = true;
        OnDeath?.Invoke();
    }

    public void Heal(float healAmount)
    {
        currentHealth = Mathf.Min(currentHealth + healAmount, maxHealth);
        OnPlayerHealthChange?.Invoke(currentHealth);
    }

    void OnCollisionEnter(Collision collision)
    {

    }
}
