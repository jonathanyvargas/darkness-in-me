using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    public Transform player;                 // Reference to the player's transform
    public Vector3 offset;                   // Optional offset
    [Range(0f, 1f)]
    public float followSpeed = 1f;           // Horizontal follow smoothing
    public float verticalParallaxSpeed = 0.1f; // Vertical movement sensitivity

    private float lastPlayerY;
    private float currentYOffset = 0f;

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player Transform not assigned!");
            enabled = false;
            return;
        }

        lastPlayerY = player.position.y;
    }

    void LateUpdate()
    {
        if (player == null) return;

        // Horizontal follow (X-axis)
        float targetX = player.position.x + offset.x;
        float newX = Mathf.Lerp(transform.position.x, targetX, followSpeed);

        // Vertical parallax (move in opposite direction of player movement)
        float playerDeltaY = player.position.y - lastPlayerY;
        currentYOffset -= playerDeltaY * verticalParallaxSpeed; // invert direction

        float newY = player.position.y + offset.y + currentYOffset;

        // Apply new position (Z remains unchanged)
        transform.position = new Vector3(newX, newY, transform.position.z);

        lastPlayerY = player.position.y;
    }
}