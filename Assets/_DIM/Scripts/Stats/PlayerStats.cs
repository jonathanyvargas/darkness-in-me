using UnityEngine;

public class PlayerStats : CharacterStats
{
    private Player player;

    protected override void Start()
    {
        base.Start();
        player = GetComponent<Player>();

        // Subscribe to the OnHealthChanged event from CharacterStats
        OnHealthChanged += HandleHealthChanged;
    }

    private void OnDestroy()
    {
        // Unsubscribe from event when no longer needed
        OnHealthChanged -= HandleHealthChanged;
    }

    private void HandleHealthChanged(int currentHealth)
    {
        // Handle UI updates or other changes when health changes
        Debug.Log($"Health changed: {currentHealth}");
    }

    public override void TakeDamage(int damageAmount)
    {
        base.TakeDamage(damageAmount);
        player.DamageEffect();
    }

    protected override void Die()
    {
        base.Die();
        player.Die();
    }
}