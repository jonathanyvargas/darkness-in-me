using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    public Transform player;         // Reference to the player's transform
    public Vector3 offset;           // Optional offset
    [Range(0f, 1f)]
    public float followSpeed = 1f;   // 1 = exact follow, <1 = smoother/parallax

    void LateUpdate()
    {
        if (player == null) return;

        Vector3 targetPos = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed);
    }
}