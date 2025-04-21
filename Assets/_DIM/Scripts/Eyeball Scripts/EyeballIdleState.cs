using UnityEngine;

public class EyeballIdleState : EyeballGroundState
{
    public EyeballIdleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animboolName, Enemy_Eyeball _enemy)
        : base(_enemyBase, _stateMachine, _animboolName, _enemy)
    {

    }

    public override void Enter()
    {
        base.Enter();
        enemy.ZeroVelocity();
        stateTimer = enemy.idleTime;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (stateTimer < 0f)
        {
            stateMachine.ChangeState(enemy.moveState);
        }
    }
}
