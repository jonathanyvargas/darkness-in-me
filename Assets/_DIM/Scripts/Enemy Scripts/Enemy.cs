using UnityEngine;

public class Enemy : Entity
{

    [SerializeField] protected LayerMask whatIsPlayer;

    [Header("Move info")]
    public float moveSpeed;
    public float idleTime;
    public float battleTime;

    [Header("Attack info")]
    public float attackDistance;
    public float attackCooldown;
    [HideInInspector] public float lastTimeAttacked;

    public EnemyStateMachine stateMachine { get; private set; }
    public string lastAnimBoolName { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new EnemyStateMachine();
    }
        
    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();
    }

    public virtual void AssignLastAnimName(string _animBoolName)
    {
        lastAnimBoolName = _animBoolName;
    }

    public virtual void AnimationFinishTrigger() => stateMachine.currentState.AnimationFinishTrigger();

    public virtual RaycastHit2D IsPlayerDectected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, 50, whatIsPlayer);

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.color = Color.yellow;

        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + attackDistance * facingDir, transform.position.y));

    }

        /// <summary>
    /// DoKnockback pushes the target in the direction the attacking entity is facing
    /// </summary>
    /// <param name="targetrb">The target taking knocback</param>
    /// <param name="knockbackSpeed">How far the target will be knocked back</param>
    public void DoKnockback(Player targetEntity, float knockbackSpeedX, float knockbackSpeedY) {
        targetEntity.TakeKnockback(knockbackSpeedX * facingDir, knockbackSpeedY);
    }

    /// <summary>
    /// TakeKnockback causes the entity to be pushed into a specified direction
    /// </summary>
    /// <param name="knockbackSpeed"></param>
    public void TakeKnockback(float knockbackSpeedX, float knockbackSpeedY) {
        //rb.linearVelocity = new Vector2(knockbackSpeedX, knockbackSpeedY);
        rb.AddForce(new Vector2(knockbackSpeedX, knockbackSpeedY), ForceMode2D.Impulse);
    }

}
