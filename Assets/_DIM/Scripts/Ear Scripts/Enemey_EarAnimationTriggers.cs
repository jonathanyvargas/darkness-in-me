using UnityEngine;

public class Enemey_EarAnimationTriggers : MonoBehaviour
{
    
    private Enemy_Ear enemy => GetComponentInParent<Enemy_Ear>();

    private void AnimationTrigger()
    {
        enemy.AnimationFinishTrigger();
    }

    private void AttrackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(enemy.attackCheck.position, enemy.attackCheckRadius);
        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Player>() != null)
            {
                PlayerStats target = hit.GetComponent<PlayerStats>();
                enemy.stats.DoDamage(target);
                //hit.GetComponent<Player>().Damage();
                //hit.GetComponent<CharacterStats>().TakeDamage(enemy.stats.damage.GetValue());
            }
        }
    }
}
