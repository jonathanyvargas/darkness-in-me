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
    /// TakeKnockback causes the entity to be pushed into a specified direction
    /// </summary>
    /// <param name="knockbackSpeed"></param>
    public override void TakeKnockback(float knockbackSpeedX, float knockbackSpeedY) {
        //rb.linearVelocity = new Vector2(knockbackSpeedX, knockbackSpeedY);
        ActivateKnockback();
        base.TakeKnockback(knockbackSpeedX, knockbackSpeedY);
    } 

    /// <summary>
    /// When the player touches the enemy, they will be knocked back and take damage
    /// </summary>
    /// <param name="other">the other 2D body that touches the enemey</param>
    /* private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerStats>().TakeDamage(1);
            other.GetComponent<Player>().TakeKnockback(10, 10);
        } 
    } */

    private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.collider.CompareTag("Player"))
    {
        collision.collider.GetComponent<PlayerStats>().TakeDamage(1);
        collision.collider.GetComponent<Player>().TakeKnockback(5 * facingDir, 5);
    }
}
}
