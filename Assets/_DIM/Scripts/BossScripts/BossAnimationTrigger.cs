using UnityEngine;

public class BossAnimationTrigger : MonoBehaviour
{
    
    private Enemy_Ear enemy => GetComponentInParent<Enemy_Ear>();

    private void AnimationTrigger()
    {
        enemy.AnimationFinishTrigger();
    }

    private void AttackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(enemy.attackCheck.position, enemy.attackCheckRadius);
        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Player>() != null)
            {
                PlayerStats target = hit.GetComponent<PlayerStats>();
                enemy.stats.DoDamage(target);
                enemy.DoKnockback(hit.GetComponent<Entity>(), enemy.stats.knockbackSpeedX.GetValue(), enemy.stats.knockbackSpeedY.GetValue());
                //hit.GetComponent<Player>().Damage();
                //hit.GetComponent<CharacterStats>().TakeDamage(enemy.stats.damage.GetValue());
            }
        }
    }
}
