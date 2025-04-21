using UnityEngine;

public class EyeballMoveState : EyeballGroundState
{
    public EyeballMoveState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animboolName, Enemy_Eyeball _enemy)
        : base(_enemyBase, _stateMachine, _animboolName, _enemy)
    {
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = 1f;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        enemy.SetVelocity(enemy.moveSpeed * enemy.facingDir, rb.linearVelocity.y);

        if (enemy.IsWallDetected() || !enemy.IsGroundDetected())
        {
            enemy.Flip();
            stateMachine.ChangeState(enemy.idleState);
        }
    }
}
