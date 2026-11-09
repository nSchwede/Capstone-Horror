using UnityEngine;

public class PauseInput : MonoBehaviour
{
    public string settingsSceneName = "SettingsMenu"; // your settings scene's exact name

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GetComponent<SceneLoader>().LoadScene(settingsSceneName);
        }
    }
}