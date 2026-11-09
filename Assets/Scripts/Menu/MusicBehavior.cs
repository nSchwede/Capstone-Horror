using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    static MusicPlayer instance;

    public AudioMixer mixer;
    public string stopInScene = "Game";

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;

        // Apply the saved volume (assumes the slider runs 0 to 1)
        float v = PlayerPrefs.GetFloat("MasterVolume", 1f);
        mixer.SetFloat("MasterVolume", Mathf.Log10(Mathf.Max(v, 0.0001f)) * 20f);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == stopInScene)
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        if (instance == this) instance = null;
    }
}
