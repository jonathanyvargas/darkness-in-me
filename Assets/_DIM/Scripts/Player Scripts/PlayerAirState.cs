using Unity.VisualScripting;
using UnityEngine;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(Player _player, PlayerStateMachine _stateMachine, string _animBooName) : base(_player, _stateMachine, _animBooName)
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
            if (Input.GetKeyDown(KeyCode.Mouse0))
                stateMachine.ChangeState(player.attackJumpState);

            if (player.IsGroundDetected())
                stateMachine.ChangeState(player.idleState);
            
            player.SetVelocity(xInput * player.moveSpeed, rb.linearVelocity.y);
        }
    }

}
