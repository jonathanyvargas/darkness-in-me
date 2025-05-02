using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(Player _player, PlayerStateMachine _stateMachine, string _animBooName) : base(_player, _stateMachine, _animBooName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        rb.linearVelocity = new Vector2(rb.linearVelocity.x, player.jumpForce);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Mouse0))
            stateMachine.ChangeState(player.attackJumpState); 

        if (rb.linearVelocity.y < 0)
            stateMachine.ChangeState(player.airState);

        if (player.isKnockbackActive)
        {
            this.KockbackStateCountdown();
        }
        else
        {
            player.SetVelocity(xInput * player.moveSpeed, rb.linearVelocity.y);
        }
    }
}
