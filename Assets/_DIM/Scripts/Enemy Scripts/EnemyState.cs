using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class EnemyState
{
    protected EnemyStateMachine stateMachine;
    protected Enemy enemyBase;
    protected Rigidbody2D rb;

    protected float stateTimer;
    protected bool triggerCalled;
    private string animboolName;
    public EnemyState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animboolName)
    {
        this.enemyBase = _enemyBase;
        this.stateMachine = _stateMachine;  
        this.animboolName = _animboolName;
    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
    }

    public virtual void Enter()
    {
        triggerCalled = false;
        rb = enemyBase.rb;
        enemyBase.anim.SetBool(animboolName, true);


    }

    public virtual void Exit()
    {
        enemyBase.anim.SetBool(animboolName, false);

        enemyBase.AssignLastAnimName(animboolName);
    }

    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }
}
