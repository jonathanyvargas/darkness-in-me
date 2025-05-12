using UnityEngine;

public class SwordAudio : MonoBehaviour
{
    public AudioClip slashSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // This method will be called from the animation event
    public void PlaySlashSound()
    {
        audioSource.PlayOneShot(slashSound);
    }
}
