using UnityEngine;

public class Entity : MonoBehaviour
{
    #region Components
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public EntityFX fx { get; private set; }   
    public CharacterStats stats { get; private set; }

    public CapsuleCollider2D cd { get; private set; }

    #endregion

    [Header("Attack info")]
    public Transform attackCheck;
    public float attackCheckRadius;

    [Header("Collision info")]
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected float groundCheckDistance;
    [SerializeField] protected Transform wallCheck;
    [SerializeField] protected float wallCheckDistance;
    [SerializeField] protected LayerMask whatIsGround;

    public float knockbackTimer;
    public float knockbackDuration = 0.3f;
    public bool isKnockbackActive = false;

    public int facingDir { get; private set; } = 1;
    protected bool facingRight = true;

    protected virtual void Awake()
    {

    }

    protected virtual void Start()
    {
        fx = GetComponent<EntityFX>();
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        stats = GetComponent<CharacterStats>();
        cd = GetComponent<CapsuleCollider2D>();
    }

    protected virtual void Update()
    {

    }

    public virtual void DamageEffect()
    {
        fx.StartCoroutine("FlashFX");
        Debug.Log(gameObject.name + " was damaged!");
    }

    #region Collision
    public virtual bool IsGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
    public virtual bool IsWallDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, wallCheckDistance, whatIsGround);

    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));
        Gizmos.DrawWireSphere(attackCheck.position, attackCheckRadius);
    }
    #endregion

    #region Flip
    public void Flip()
    {
        facingDir = facingDir * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    public void FlipController(float _x)
    {
        if (_x > 0 && !facingRight)
            Flip();
        else if (_x < 0 && facingRight)
            Flip();
    }
    #endregion

    #region Velocity
    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        rb.linearVelocity = new Vector2(_xVelocity, _yVelocity);
        FlipController(_xVelocity);
    }
    #endregion

    public void ZeroVelocity()
    {
        rb.linearVelocity = Vector2.zero;
    }

    public virtual void Die()
    {

    }

    /// <summary>
    /// DoKnockback pushes the target in the direction the attacking entity is facing
    /// </summary>
    /// <param name="targetrb">The target taking knocback</param>
    /// <param name="knockbackSpeed">How far the target will be knocked back</param>
    public void DoKnockback(Entity targetEntity, float knockbackSpeedX, float knockbackSpeedY) {
        targetEntity.TakeKnockback(knockbackSpeedX * facingDir, knockbackSpeedY);
    }

    /// <summary>
    /// TakeKnockback causes the entity to be pushed into a specified direction
    /// </summary>
    /// <param name="knockbackSpeed"></param>
    public virtual void TakeKnockback(float knockbackSpeedX, float knockbackSpeedY) {
        //rb.linearVelocity = new Vector2(knockbackSpeedX, knockbackSpeedY);
        if(stats.getCurrentHealth() > 0) {
            ActivateKnockback();
            rb.AddForce(new Vector2(knockbackSpeedX * ((100 - stats.knockbackResistPercent.GetValue())/100), knockbackSpeedY * ((100 - stats.knockbackResistPercent.GetValue())/100)), ForceMode2D.Impulse);
        }
    }

    public void ActivateKnockback()
    {
        isKnockbackActive = true;
        knockbackTimer = knockbackDuration;
    }
}
