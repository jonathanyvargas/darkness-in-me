using UnityEngine;

public class BossIdleState : EnemyState
{
    protected Boss enemy;

    protected Transform player;
    public BossIdleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animboolName, Boss _enemy) : base(_enemy, _stateMachine, _animboolName)
    {
        enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Boss In Idle State");
        enemy.ZeroVelocity();
        player = GameObject.Find("Player").transform;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (enemy.playerInArena)
        {
            Debug.Log("Transition to Battlestate");
            stateMachine.ChangeState(enemy.battleState);
        }
    }
}
