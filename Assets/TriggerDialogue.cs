using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class DialogueUI : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Image characterImage;
    public TextMeshProUGUI dialogueText;
    public Sprite characterSprite;
    [TextArea] public string initialDialogue;
    public float dialogueDuration = 5f;
    public float typingSpeed = 0.05f;

    [Header("Audio")]
    public AudioSource blipAudioSource; // 👈 Assign in Inspector
    public AudioClip blipClip;          // 👈 Optional, if you want to set it separately

    void Start()
    {
        ShowDialogue(characterSprite, initialDialogue);
        StartCoroutine(HideAfterSeconds(dialogueDuration));
    }

    public void ShowDialogue(Sprite sprite, string text)
    {
        dialoguePanel.SetActive(true);
        characterImage.sprite = sprite;
        StartCoroutine(TypeText(text));
    }

    IEnumerator TypeText(string text)
    {
        dialogueText.text = "";

        foreach (char c in text)
        {
            dialogueText.text += c;

            // Play blip sound for visible characters only (skip spaces, etc.)
            if (blipAudioSource != null && c != ' ')
            {
                blipAudioSource.PlayOneShot(blipClip);
            }

            yield return new WaitForSeconds(typingSpeed);
        }
    }

    IEnumerator HideAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        HideDialogue();
    }

    public void HideDialogue()
    {
        dialoguePanel.SetActive(false);
    }
}