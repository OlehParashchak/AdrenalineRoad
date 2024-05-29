using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action LoseGameEvent;

    [SerializeField] private HealthBar healthBar;
    [SerializeField] private Obstacle obstacle;

    [SerializeField] private int maxHealth = 100;
    public int MaxHealth => maxHealth;

    private int currentHealth;
    public int CurrentHealth
    {
        get { return currentHealth; }
        set
        {
            currentHealth = Mathf.Clamp(value, 0, maxHealth);
            healthBar.SetHealth(currentHealth);
            if (currentHealth <= 0)
            {
                LoseGameEvent?.Invoke();
            }
        }
    }

    private void Start()
    {
        obstacle.TakeDamageEvent += TakeDamage;

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
    }

    private void OnDisable()
    {
        obstacle.TakeDamageEvent -= TakeDamage;
    }

    public void TakeDamage(int damage)
    {
        if (currentHealth > 0)
        {
            CurrentHealth -= damage;
        }
    }
}
