using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string nextSceneName; // Set the next scene name in the Inspector

    void Start()
    {
        // Attach this script to your button and set the next scene name in the Inspector
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnClick);
        }
    }

    void OnClick()
    {
        // Load the next scene
        SceneManager.LoadScene(nextSceneName);
    }
}
