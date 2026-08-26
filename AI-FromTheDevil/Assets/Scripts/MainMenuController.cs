using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("Запуск гри...");
        SceneManager.LoadScene("TestGame");
    }

    public void ExitGame()
    {
        Debug.Log("Вихід з гри...");

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}