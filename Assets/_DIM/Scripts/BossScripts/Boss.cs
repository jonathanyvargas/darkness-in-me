using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using Unity.Cinemachine;

public class Boss : Enemy
{
    public BossIdleState idleState { get; private set; }
    public BossBattleState battleState { get; private set; }
    public BossLaserState laserState { get; private set; }
    public BossDeathState deathState { get; private set; }
    public bool playerInArena = false;
    public bool secondPhase = false;
    public Transform LaserPhaseSpawn;
    public  CinemachineCamera bossCutsceneCamera;
    public  CinemachineCamera playerCutsceneCamera;
    [SerializeField] public GameObject laserPrefab;
    [SerializeField] public Transform laserOrigin;
    [SerializeField] public LayerMask hitLayers;
    Transform player;
    protected override void Awake()
    {
        base.Awake();

        idleState = new BossIdleState(this, stateMachine, "Idle", this);
        battleState = new BossBattleState(this, stateMachine, "Move", this);
        laserState = new BossLaserState(this, stateMachine, "Laser", this);
        deathState = new BossDeathState(this, stateMachine, "Idle", this);
    }

    protected override void Start()
    {
        base.Start();
        player = GameObject.Find("Player").transform;
        stateMachine.Initialize(idleState);

    }

    protected override void Update()
    {
        base.Update();
    }

    public override void Die()
    {
        base.Die();
        //stateMachine.ChangeState(deathState);   
    }
}
