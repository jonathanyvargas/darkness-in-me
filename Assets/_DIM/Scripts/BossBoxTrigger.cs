using UnityEngine;
using Unity.Cinemachine;
using System.Collections;


public class BossBoxTrigger : MonoBehaviour
{
    [SerializeField] private CinemachineCamera bossCutsceneCamera;
    [SerializeField] private CinemachineCamera playerCamera;
    [SerializeField] private GameObject barrierPrefab;
    [SerializeField] private Transform[] barrierSpawnPoints;
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
    private IEnumerator CutsceneRoutine()
    {
        SpawnBarriers();
        bossCutsceneCamera.Priority = 20;
        yield return new WaitForSeconds(cutsceneDuration);
        bossCutsceneCamera.Priority = 5;
        playerCamera.Priority = 20;
        boss.playerInArena = true;
    }

    private void SpawnBarriers()
    {
        foreach (var point in barrierSpawnPoints)
        {
            Debug.Log("Spawned barriers!");
            Instantiate(barrierPrefab, point.position, Quaternion.identity);
        }
    }
}
