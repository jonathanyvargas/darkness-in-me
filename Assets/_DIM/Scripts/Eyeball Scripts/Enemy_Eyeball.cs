using UnityEngine;
using UnityEngine.Rendering;

public class Enemy_Eyeball : Enemy
{

    #region States

    public EyeballIdleState idleState { get; private set; }

    public EyeballMoveState moveState { get; private set; }
    public EyeballAttackState attackState { get; private set; }
    public EyeballDeathState deathState { get; private set; }
    public EyeballBattleState battleState { get; private set; }

    #endregion

    protected override void Awake()
    {
        base.Awake();

        idleState = new EyeballIdleState(this, stateMachine, "Idle", this);
        moveState = new EyeballMoveState(this, stateMachine, "Move", this);
        battleState = new EyeballBattleState(this, stateMachine, "Move", this);
        attackState = new EyeballAttackState(this, stateMachine, "Attack", this);
        deathState = new EyeballDeathState(this, stateMachine, "Idle", this);
    }

    protected override void Start()
    {
        base.Start();

        stateMachine.Initialize(idleState);

    }

    protected override void Update()
    {
        base.Update();
    }
    public override void Die()
    {
        base.Die();
        stateMachine.ChangeState(deathState);
    }
}
