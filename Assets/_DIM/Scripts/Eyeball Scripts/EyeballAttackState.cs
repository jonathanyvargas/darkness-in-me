using UnityEngine;

public class EyeballAttackState : EnemyState
{
    private Enemy_Eyeball enemy;

    public EyeballAttackState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animboolName, Enemy_Eyeball _enemy) : base(_enemy, _stateMachine, _animboolName)
    {
        enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();

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
