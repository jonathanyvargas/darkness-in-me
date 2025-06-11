using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Required for scene management
using System.Collections;

public class CreditsScroller : MonoBehaviour
{
    public RectTransform contentRect;
    public float scrollSpeed = 50f;
    public float holdDuration = 3f;
    public float fadeDuration = 1.5f;
    public CanvasGroup canvasGroup; // Assign in Inspector

    private float topY;
    private float bottomY;
    private bool scrolling = true;

    private void Start()
    {
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 0f;
            StartCoroutine(FadeIn());
        }

        topY = contentRect.anchoredPosition.y;
        bottomY = topY + contentRect.rect.height;
    }

    private void Update()
    {
        if (!scrolling) return;

        Vector2 pos = contentRect.anchoredPosition;
        pos.y += scrollSpeed * Time.deltaTime;
        contentRect.anchoredPosition = pos;

        // Restart scene when Y position reaches or exceeds 1717
        if (pos.y >= 1717f)
        {
            scrolling = false;
            Debug.Log("Restarting scene at Y position 1717...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        // Optional: also stop when reaching bottomY
        if (pos.y >= bottomY)
        {
            scrolling = false;
            StartCoroutine(ExitAfterHold());
        }
    }

    private IEnumerator FadeIn()
    {
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsed / fadeDuration);
            canvasGroup.alpha = alpha;
            elapsed += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = 1f;
    }

    private IEnumerator ExitAfterHold()
    {
        yield return new WaitForSeconds(holdDuration);
        Debug.Log("Credits finished. Transitioning...");
        // SceneManager.LoadScene("MainMenu");
    }
}
