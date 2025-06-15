using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Control BGM Volume with Slider (Menu)
/// </summary>

public class BGMManager : MonoBehaviour
{
    public AudioSource bgmSource;
    public Slider volumeSlider;

    void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("BGMVolume", 1f);
        bgmSource.volume = savedVolume;
        volumeSlider.value = savedVolume;

        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    // Save the volume
    public void SetVolume(float value)
    {
        bgmSource.volume = value;
        PlayerPrefs.SetFloat("BGMVolume", value);
    }
}