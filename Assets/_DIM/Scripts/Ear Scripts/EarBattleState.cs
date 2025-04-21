using UnityEngine;

public class EarBattleState : EnemyState
{
    private Transform player;
    private Enemy_Ear enemy;
    private int moveDir;

    public EarBattleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animboolName, Enemy_Ear _enemy) : base(_enemy, _stateMachine, _animboolName)
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

        enemy.SetVelocity(enemy.moveSpeed * moveDir, rb.linearVelocity.y); 
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
