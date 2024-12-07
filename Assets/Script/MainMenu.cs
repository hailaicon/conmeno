using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void GamePlay1()
    {
        SceneManager.LoadScene("gameplay1");
    }
    public void GotoSettingMenu()
    {
        SceneManager.LoadScene("Setting");
    }

    public void GotoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
