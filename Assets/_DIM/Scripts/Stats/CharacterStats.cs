using System;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
/// <summary>
/// This class is for the tracking and modification of numerical statistics about the entity/character like the health and knockback force.
/// If you're looking to change the physics or behavior of the entity/character, visit the entity class
/// </summary>
public class CharacterStats : MonoBehaviour
{

    public Stats damage;
    public Stats maxHealth;
    public Stats knockbackSpeedX;
    public Stats knockbackSpeedY;
    public Stats knockbackResistPercent;

    [SerializeField] private int currentHealth;

    protected virtual void Start()
    {
        currentHealth = maxHealth.GetValue();
    }
    
    public virtual void DoDamage (CharacterStats _targetStats)
    {
        int totalDamage = damage.GetValue();
        _targetStats.TakeDamage(totalDamage);
    }

    public virtual void TakeDamage(int _damage)
    {
        currentHealth -= _damage;

        Debug.Log(_damage);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Return the entity's current health
    /// </summary>
    /// <returns>The entity's current health</returns>
    public int getCurrentHealth() {
        return currentHealth;
    }

    protected virtual void Die()
    {
        //throw new NotImplementedException();
    }
}
