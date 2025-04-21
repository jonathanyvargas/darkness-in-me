using System;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    public Stats damage;
    public Stats maxHealth;

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

    protected virtual void Die()
    {
        //throw new NotImplementedException();
    }
}
