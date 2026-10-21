using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider volumeSlider;

    void Start()
    {
        float saved = PlayerPrefs.GetFloat("MasterVolume", 1f);
        volumeSlider.value = saved;
        SetVolume(saved);
    }

    public void SetVolume(float value)
    {
        mixer.SetFloat("MasterVolume", Mathf.Log10(value) * 20f);
        PlayerPrefs.SetFloat("MasterVolume", value);
    }
}