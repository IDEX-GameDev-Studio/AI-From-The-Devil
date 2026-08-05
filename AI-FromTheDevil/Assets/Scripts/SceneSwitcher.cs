using UnityEngine;
using UnityEngine.SceneManagement;
//script was made by mercy (Ivan Vasilyev)
public class SceneSwitcher : MonoBehaviour
{

    public void LoadSceneByName(string sceneName)
    {
        
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("error with scene, wrong name!");
        }
    }
}
