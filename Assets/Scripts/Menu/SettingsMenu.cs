using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


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
    public void QuitGame()
    {
        StartCoroutine(QuitAfterDelay());
    }

    IEnumerator QuitAfterDelay()
    {
        yield return new WaitForSecondsRealtime(0.3f);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
    public void SetVolume(float value)
    {
        mixer.SetFloat("MasterVolume", Mathf.Log10(value) * 20f);
        PlayerPrefs.SetFloat("MasterVolume", value);
    }
}