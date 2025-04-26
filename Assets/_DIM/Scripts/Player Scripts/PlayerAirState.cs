using Unity.VisualScripting;
using UnityEngine;

public class PlayerAirState : PlayerState
{
    private float knockbackTimer;
    private float knockbackDuration = 0.3f;
    private bool isKnockbackActive = false;
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

    public void ActivateKnockback()
    {
        isKnockbackActive = true;
        knockbackTimer = knockbackDuration;
    }

    public override void Update()
    {
         base.Update();

        if (isKnockbackActive)
        {
            knockbackTimer -= Time.deltaTime;
            if (knockbackTimer <= 0)
                isKnockbackActive = false;
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
