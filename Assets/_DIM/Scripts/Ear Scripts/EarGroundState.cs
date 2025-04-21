using UnityEngine;

public class EarGroundState : EnemyState
{
    protected Enemy_Ear enemy;

    protected Transform player;
    public EarGroundState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animboolName, Enemy_Ear _enemy) : base(_enemy, _stateMachine, _animboolName)
    {
        enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();

        player = GameObject.Find("Player").transform;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (enemy.IsPlayerDectected() || Vector2.Distance(player.transform.position, enemy.transform.position) < 4)
        {
            stateMachine.ChangeState(enemy.battleState);
        }
    }
}
