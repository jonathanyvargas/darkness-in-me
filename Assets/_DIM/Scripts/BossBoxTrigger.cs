using UnityEngine;
using Unity.Cinemachine;
using System.Collections;

public class BossBoxTrigger : MonoBehaviour
{
    [SerializeField] private CinemachineCamera bossCutsceneCamera;
    [SerializeField] private CinemachineCamera playerCamera;
    [SerializeField] private GameObject barrierPrefab1;
    [SerializeField] private GameObject barrierPrefab2;
    [SerializeField] private Transform[] barrier1SpawnPoints;
    [SerializeField] private Transform[] barrier2SpawnPoints;
    [SerializeField] private float cutsceneDuration = 3f;
    [SerializeField] private Boss boss;
    bool played = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !played)
        {
            played = true;
            Debug.Log("Play cutscene");
            StartCoroutine(CutsceneRoutine());
        }
    }

    private void Start()
    {
        // Start with the player camera active
        playerCamera.Priority = 20;
        bossCutsceneCamera.Priority = 5;
    }

    private IEnumerator CutsceneRoutine()
    {
        SpawnBarriers();

        // Temporarily raise boss cutscene camera priority
        bossCutsceneCamera.Priority = 30;

        yield return new WaitForSeconds(cutsceneDuration);

        // Lower boss cutscene camera priority so player camera takes over
        bossCutsceneCamera.Priority = 5;

        // Let the boss know the player has entered the arena
        boss.playerInArena = true;
    }

    private void SpawnBarriers()
    {
        foreach (var point in barrier1SpawnPoints)
        {
            Instantiate(barrierPrefab1, point.position, Quaternion.identity);
            Debug.Log("Spawned barrierPrefab1 at " + point.name);
        }

        foreach (var point in barrier2SpawnPoints)
        {
            Instantiate(barrierPrefab2, point.position, Quaternion.identity);
            Debug.Log("Spawned barrierPrefab2 at " + point.name);
        }
    }
}