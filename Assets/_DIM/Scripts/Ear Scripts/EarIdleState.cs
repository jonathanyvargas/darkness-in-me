using UnityEngine;
using UnityEngine.UIElements;

public class EarIdleState : EarGroundState
{

    public EarIdleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animboolName, Enemy_Ear _enemy) : base(_enemyBase, _stateMachine, _animboolName, _enemy)
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
