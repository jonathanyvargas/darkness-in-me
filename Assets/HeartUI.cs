using UnityEngine;
using UnityEngine.UI;

public class HeartUI : MonoBehaviour
{
    [Header("Heart UI Elements")]
    public Image[] hearts;               // Assign via Inspector (heart1, heart2, etc.)
    public Sprite fullHeart;            // Assign full heart sprite
    public Sprite emptyHeart;           // Assign empty heart sprite

    [Header("Player Reference")]
    public PlayerStats playerStats;     // Assign manually in Inspector

    private void Start()
    {
        if (playerStats != null)
        {
            playerStats.OnHealthChanged += UpdateHearts;
            UpdateHearts(playerStats.getCurrentHealth()); // Initialize correctly
        }
    }

    private void OnDestroy()
    {
        if (playerStats != null)
        {
            playerStats.OnHealthChanged -= UpdateHearts;
        }
    }

    private void UpdateHearts(int currentHealth)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].sprite = (i < currentHealth) ? fullHeart : emptyHeart;
            hearts[i].enabled = true; // Always enabled
        }
    }
}
