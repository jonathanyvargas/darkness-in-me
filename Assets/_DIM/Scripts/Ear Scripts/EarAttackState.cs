using UnityEngine;

public class EarAttackState : EnemyState
{

    private Enemy_Ear enemy;

    public EarAttackState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animboolName, Enemy_Ear enemy) : base(_enemyBase, _stateMachine, _animboolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        //enemy.ZeroVelocity();
        stateTimer = enemy.idleTime;
    }

    public override void Exit()
    {
        base.Exit();

        enemy.lastTimeAttacked = Time.time;
    }

    public override void Update()
    {
        base.Update();

        enemy.ZeroVelocity();

        if (triggerCalled)
        {
            stateMachine.ChangeState(enemy.battleState);
        }
    }
}
