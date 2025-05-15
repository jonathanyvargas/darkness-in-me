using UnityEngine;
using UnityEngine.XR;


public class BossBattleState : EnemyState
{
    private Transform player;
    private Boss enemy;
    private int moveDir;
    
    public BossBattleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animboolName, Boss _enemy) : base(_enemy, _stateMachine, _animboolName)
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

        float deltaX = player.position.x - enemy.transform.position.x;

        if (Mathf.Abs(deltaX) > 3f) // deadzone of 0.1 units
        {
            moveDir = deltaX > 0 ? 1 : -1;
        }


        if (enemy.isKnockbackActive)
        {
            enemy.knockbackTimer -= Time.deltaTime;
            if (enemy.knockbackTimer <= 0)
                enemy.isKnockbackActive = false;
        }
        else {
            Debug.Log("Boss Moving! X =" + enemy.moveSpeed); 
            if(enemy.transform.position.y > 54) {
                enemy.SetVelocity(enemy.moveSpeed * moveDir, -1); 
            }
            else {
                enemy.SetVelocity(enemy.moveSpeed * moveDir, 0);
            }
        }

        if(((enemy.stats.getCurrentHealth() == 50) || (enemy.stats.getCurrentHealth() == 20)) && !enemy.secondPhase) {
            enemy.secondPhase = true;
            stateMachine.ChangeState(enemy.laserState);
        }

        if(enemy.stats.getCurrentHealth() <= 0) {
            stateMachine.ChangeState(enemy.deathState);
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
