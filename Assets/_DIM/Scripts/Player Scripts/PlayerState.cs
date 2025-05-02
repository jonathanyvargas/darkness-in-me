using NUnit.Framework.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine stateMachine;

    protected Player player;

    private string animBoolName;

    protected float xInput;

    protected Rigidbody2D rb;

    protected float stateTimer;

    protected bool triggerCalled;
/*     protected float knockbackTimer;
    protected float knockbackDuration = 0.3f;
    protected bool isKnockbackActive = false; */

    public PlayerState(Player _player, PlayerStateMachine _stateMachine, string _animBooName)
    {
        this.player = _player;
        this.stateMachine = _stateMachine;  
        this.animBoolName = _animBooName;
    }

    public virtual void Enter()
    {
        player.anim.SetBool(animBoolName, true);
        rb = player.rb;
        triggerCalled = false;
    }

    public virtual void Update()
    {
   
        stateTimer -= Time.deltaTime;   

        xInput = Input.GetAxisRaw("Horizontal");
        player.anim.SetFloat("yVelocity", rb.linearVelocity.y);
    }

    public virtual void Exit()
    {
        player.anim.SetBool(animBoolName, false);

    }

    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }

    public void KockbackStateCountdown() {
        player.knockbackTimer -= Time.deltaTime;
        if (player.knockbackTimer <= 0)
            player.isKnockbackActive = false;
    }

}
