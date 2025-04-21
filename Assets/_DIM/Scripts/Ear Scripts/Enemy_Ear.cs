using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Enemy_Ear : Enemy
{

    public EarIdleState idleState { get; private set; }
    public EarMoveState moveState { get; private set; }
    public EarBattleState battleState { get; private set; }
    public EarAttackState attackState { get; private set; }
    public EarDeathState deathState { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        idleState = new EarIdleState(this, stateMachine, "Idle", this);
        moveState = new EarMoveState(this, stateMachine, "Move", this);
        battleState = new EarBattleState(this, stateMachine, "Move", this);
        attackState = new EarAttackState(this, stateMachine, "Attack", this);
        deathState = new EarDeathState(this, stateMachine, "Idle", this);
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
