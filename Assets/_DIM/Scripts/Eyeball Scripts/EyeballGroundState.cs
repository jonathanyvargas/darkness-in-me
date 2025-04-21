using UnityEngine;

public class EyeballGroundState : EnemyState
{
    protected Enemy_Eyeball enemy;

    protected Transform player;
    public EyeballGroundState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animboolName, Enemy_Eyeball _enemy) : base(_enemy, _stateMachine, _animboolName)
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
