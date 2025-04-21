using UnityEngine;

public class Enemy_EyeballAnimationTriggers : MonoBehaviour
{
    private Enemy_Eyeball enemy => GetComponentInParent<Enemy_Eyeball>();

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
