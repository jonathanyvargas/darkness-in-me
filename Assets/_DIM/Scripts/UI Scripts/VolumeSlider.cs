using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider volumeSlider;

    void Start()
    {
        // Initialize the slider value from saved settings or default
        volumeSlider.value = AudioListener.volume;

        // Listen for changes
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    void SetVolume(float value)
    {
        AudioListener.volume = value;
        //Save the change so the the volume setting stays across sessoons
        PlayerPrefs.SetFloat("Volume", value);
    }
}
