using System;
using UnityEngine;

/// <summary>
/// This class is for the tracking and modification of numerical statistics about the entity/character like health and knockback force.
/// If you're looking to change the physics or behavior of the entity/character, visit the entity class.
/// </summary>
public class CharacterStats : MonoBehaviour
{
    public Stats damage;
    public Stats maxHealth;
    public Stats knockbackSpeedX;
    public Stats knockbackSpeedY;
    public Stats knockbackResistPercent;

    [SerializeField] private int currentHealth;

    // ✅ Instance-based event — no longer static!
    public event Action<int> OnHealthChanged;

    protected virtual void Start()
    {
        currentHealth = maxHealth.GetValue();
        OnHealthChanged?.Invoke(currentHealth); // Notify UI on start
    }

    public virtual void DoDamage(CharacterStats _targetStats)
    {
        int totalDamage = damage.GetValue();
        _targetStats.TakeDamage(totalDamage);
    }

    public virtual void TakeDamage(int _damage)
    {
        currentHealth -= _damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth.GetValue());

        Debug.Log($"Damage taken: {_damage}, Current Health: {currentHealth}");

        OnHealthChanged?.Invoke(currentHealth); // Notify only this instance's listeners

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Return the entity's current health
    /// </summary>
    public int getCurrentHealth()
    {
        return currentHealth;
    }

    protected virtual void Die()
    {
        Debug.Log($"{gameObject.name} died.");
    }
}