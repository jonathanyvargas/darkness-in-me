using UnityEngine;


public class BossLaserState : EnemyState
{
    private Transform player;
    private Boss enemy;
    private GameObject activeLaser;
    private int timer = 50;
    public BossLaserState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animboolName, Boss _enemy) : base(_enemy, _stateMachine, _animboolName)
    {
        enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
        enemy.bossCutsceneCamera.Priority = 20;
        enemy.ZeroVelocity();
        enemy.rb.position = new Vector2(enemy.LaserPhaseSpawn.position.x, enemy.LaserPhaseSpawn.position.y);
    }
    public override void Update()
    {
        base.Update();
        enemy.SetVelocity(10, 0);
        if(timer == 0) {
            activeLaser = Object.Instantiate(enemy.laserPrefab, enemy.laserOrigin.position, Quaternion.identity);
            timer = 50;
        }
        else {
            timer--;
        }
        if(enemy.rb.position.x > -10) {
            Debug.Log("Finished laser");
            enemy.ZeroVelocity();
            stateMachine.ChangeState(enemy.battleState);
        }
        
    }

    public override void Exit()
    {
        enemy.bossCutsceneCamera.Priority = 5;
        enemy.playerCutsceneCamera.Priority = 20;
        base.Exit();
    }

    public void FireLaser()
    {
        //activeLaser.transform.right = direction; // or .up depending on sprite orientation

        // Scale laser along its length axis
         // assumes sprite is along Y
    }

}
