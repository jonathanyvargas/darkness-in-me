using UnityEngine;
using Unity.Cinemachine;
using System.Collections;

public class Boss : Enemy
{
    public BossIdleState idleState { get; private set; }
    public BossBattleState battleState { get; private set; }
    public BossLaserState laserState { get; private set; }
    public BossDeathState deathState { get; private set; }
    public bool playerInArena = false;
    public bool secondPhase = false;
    public Transform LaserPhaseSpawn;
    public CinemachineCamera bossCutsceneCamera;
    public CinemachineCamera playerCutsceneCamera;

    [SerializeField] public GameObject laserPrefab;
    [SerializeField] public Transform laserOrigin;
    [SerializeField] public LayerMask hitLayers;

    private Transform player;

    [Header("Fade Out Settings")]
    [Tooltip("Assign the GameObject with the SpriteRenderer to fade out")]
    [SerializeField] private GameObject bossAnimator;

    private SpriteRenderer spriteRenderer;

    [SerializeField] private float fadeDuration = 2f; // Duration of the fade

    protected override void Awake()
    {
        base.Awake();

        idleState = new BossIdleState(this, stateMachine, "Idle", this);
        battleState = new BossBattleState(this, stateMachine, "Move", this);
        laserState = new BossLaserState(this, stateMachine, "Laser", this);
        deathState = new BossDeathState(this, stateMachine, "Idle", this);

        if (bossAnimator != null)
            spriteRenderer = bossAnimator.GetComponent<SpriteRenderer>();
        else
            Debug.LogWarning("BossAnimator GameObject not assigned on Boss script.");
    }

    protected override void Start()
    {
        base.Start();
        player = GameObject.Find("Player").transform;
        stateMachine.Initialize(idleState);
    }

    public override void Die()
    {
        base.Die();

        if (spriteRenderer != null)
            StartCoroutine(FadeOutAndDestroy());
        else
        {
            Debug.LogError("SpriteRenderer not found on bossAnimator GameObject, destroying immediately.");
            Destroy(gameObject);
        }
    }

    private IEnumerator FadeOutAndDestroy()
    {
        float elapsed = 0f;
        Color originalColor = spriteRenderer.color;

        while (elapsed < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);
            spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            elapsed += Time.deltaTime;
            yield return null;
        }

        spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
        Destroy(gameObject);
    }
}
