using UnityEngine;

public class EyeballDeathState : EnemyState
{
    private Enemy_Eyeball enemy;
    public EyeballDeathState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animboolName, Enemy_Eyeball _enemy) : base(_enemyBase, _stateMachine, _animboolName)
    {
        this.enemy = _enemy;
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    public override void Enter()
    {
        base.Enter();

        enemy.anim.SetBool(enemy.lastAnimBoolName, true);
        enemy.anim.speed = 0;
        enemy.cd.enabled = false;

        stateTimer = .05f;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
    }
}
