using Unity.VisualScripting;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Player _player, PlayerStateMachine _stateMachine, string _animBooName) : base(_player, _stateMachine, _animBooName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (player.isKnockbackActive)
        {
            this.KockbackStateCountdown();
        }
        else
        {
            player.SetVelocity(xInput * player.moveSpeed, rb.linearVelocity.y);
        }

        if (xInput == 0)
            stateMachine.ChangeState(player.idleState);
    }
}
