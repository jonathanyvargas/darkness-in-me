using UnityEngine;
using System.Collections;

public class MusicTrigger2D : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip defaultSong;
    public AudioClip heavenSong;

    [Range(0f, 1f)] public float defaultVolume = 1f;
    [Range(0f, 1f)] public float heavenVolume = 0.7f;

    public float fadeDuration = 1.5f;
    private bool isSwitching = false;

    void Start()
    {
        if (audioSource && defaultSong)
        {
            audioSource.clip = defaultSong;
            audioSource.volume = defaultVolume;
            audioSource.Play();
        }
    }

    void Update()
    {
        // This ensures volume updates live if changed in the Inspector
        if (audioSource != null)
        {
            // Optionally, you could expose a slider or adjust this dynamically
            audioSource.volume = Mathf.Clamp(audioSource.volume, 0f, 1f);  // Ensure volume stays within the valid range
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isSwitching && other.gameObject.name == "heaven_background")
        {
            StartCoroutine(SmoothSwitch(heavenSong, heavenVolume));
        }
    }

    IEnumerator SmoothSwitch(AudioClip newClip, float newVolume)
    {
        isSwitching = true;

        // Fade out the current music
        float startVolume = audioSource.volume;
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(startVolume, 0f, t / fadeDuration);
            yield return null;
        }

        audioSource.Stop();
        
        // Change the clip and ensure volume is reset correctly
        audioSource.clip = newClip;
        audioSource.volume = 0f;
        audioSource.Play();

        // Fade in the new music
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(0f, newVolume, t / fadeDuration);
            yield return null;
        }

        audioSource.volume = newVolume;
        isSwitching = false;
    }
}