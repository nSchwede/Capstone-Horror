using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using static BackButton;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneHistory.previousScene = SceneManager.GetActiveScene().name;
        StartCoroutine(LoadAfterDelay(sceneName));
    }

    public void GoBack()
    {
        StartCoroutine(LoadAfterDelay(SceneHistory.previousScene));
    }

    IEnumerator LoadAfterDelay(string sceneName)
    {
        yield return new WaitForSecondsRealtime(0.3f);
        SceneManager.LoadScene(sceneName);
    }
}
