using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        StartCoroutine(LoadAfterDelay("SampleScene"));
    }

    public void OpenSettings()
    {
        StartCoroutine(LoadAfterDelay("SettingsMenu")); // use your scene's exact name
    }

    public void BackToMenu()
    {
        StartCoroutine(LoadAfterDelay("MainMenu"));
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

    IEnumerator LoadAfterDelay(string sceneName)
    {
        yield return new WaitForSecondsRealtime(0.3f);
        SceneManager.LoadScene(sceneName);
    }
}