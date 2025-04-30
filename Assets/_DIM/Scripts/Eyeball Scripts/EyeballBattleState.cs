using UnityEngine;

public class EyeballBattleState : EnemyState
{
    private Transform player;
    private Enemy_Eyeball enemy;
    private int moveDir;
    public EyeballBattleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animboolName, Enemy_Eyeball _enemy) : base(_enemyBase, _stateMachine, _animboolName)
    {
        enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();

        player = GameObject.Find("Player").transform;
    }

    public override void Update()
    {
        base.Update();

        if (enemy.IsPlayerDectected())
        {
            stateTimer = enemy.battleTime;

            if (enemy.IsPlayerDectected().distance < enemy.attackDistance)
            {
                if (CanAttack())
                {
                    stateMachine.ChangeState(enemy.attackState);
                }
            }
        }
        else
        {
            if (stateTimer < 0 || Vector2.Distance(player.transform.position, enemy.transform.position) > 5)
            {
                enemy.ZeroVelocity();
                stateMachine.ChangeState(enemy.idleState);
            }
        }

        if (player.position.x > enemy.transform.position.x)
        {
            moveDir = 1;
        }
        else if (player.position.x < enemy.transform.position.x)
        {
            moveDir = -1;
        }

        if (enemy.isKnockbackActive)
        {
            enemy.knockbackTimer -= Time.deltaTime;
            if (enemy.knockbackTimer <= 0)
                enemy.isKnockbackActive = false;
        }
        else {
            enemy.SetVelocity(enemy.moveSpeed * moveDir, rb.linearVelocity.y); 
        }
    }
    public override void Exit()
    {
        base.Exit();
    }
    private bool CanAttack()
    {
        if (Time.time >= enemy.lastTimeAttacked + enemy.attackCooldown)
        {
            enemy.lastTimeAttacked = Time.time;
            return true;
        }
        Debug.Log("Can't attack yet. Attack on cooldown");
        return false;
    }
}
