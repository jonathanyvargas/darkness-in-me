using UnityEngine;

public class Player : Entity
{

    [Header("Move info")]
    public float moveSpeed = 12.0f;
    public float jumpForce;

    [Header("Dash info")]
    [SerializeField] private float dashCooldown;
    private float dashUsageTimer;
    public float dashSpeed;
    public float dashDuration;
    public float dashDir {  get; private set; }

    [Header("UI")]
    [SerializeField] private UIManager UIManager;

    public PlayerStateMachine stateMachine {  get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerDashState dashState { get; private set; }
    public PlayerAttackIdleState attackIdleState { get; private set; }
    public PlayerAttackMoveState attackMoveState { get; private set; }
    public PlayerAttackJumpState attackJumpState { get; private set; }
    public PlayerDeathState deathState { get; private set; }


    protected override void Awake()
    {
        base.Awake();
        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
        airState = new PlayerAirState(this, stateMachine, "Jump");
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
        dashState = new PlayerDashState(this, stateMachine, "Dash");
        attackIdleState = new PlayerAttackIdleState(this, stateMachine, "AttackIdle");
        attackMoveState = new PlayerAttackMoveState(this, stateMachine, "AttackMove");
        attackJumpState = new PlayerAttackJumpState(this, stateMachine, "AttackJump");
        deathState = new PlayerDeathState(this, stateMachine, "Die");
    }

    protected override void Start()
    {
        base.Start();

        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();

        stateMachine.currentState.Update();

        CheckForDashInput();
        CheckForEscape();
    }

    public void AnimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();

    private void CheckForDashInput()
    {

        dashUsageTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftShift) && dashUsageTimer < 0)
        {
            dashUsageTimer = dashCooldown;
            dashDir = Input.GetAxisRaw("Horizontal");

            if (dashDir == 0)
            {
                dashDir = facingDir;
            }

            stateMachine.ChangeState(dashState);
        }
    }

    private void CheckForEscape() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(!UIManager.isPauseScreenActive()) {
                UIManager.Pause();
            }
            else{
                UIManager.Resume();
            }
        }
    }

    public override void Die()
    {
        base.Die();
        stateMachine.ChangeState(deathState);
    }

}
