using UnityEngine;
using UnityEngine.UI;

public class ButtonClickSounds : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clickSound;

    void Start()
    {
        Button[] buttons = FindObjectsByType<Button>(FindObjectsInactive.Include, FindObjectsSortMode.None);

        foreach (Button b in buttons)
        {
            b.onClick.AddListener(() => source.PlayOneShot(clickSound));
        }
    }
}