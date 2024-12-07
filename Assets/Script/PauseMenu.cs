using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject setting, PauseeMenu;
    public GameObject canvas;
    public int i = 2;
    public bool settingin;
    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (i % 2 == 0 && Input.GetKeyDown(KeyCode.Escape))
        {
            canvas.SetActive(true);
            Time.timeScale = 0;
        }
        if (i % 2 != 0 && Input.GetKeyDown(KeyCode.Escape))
        {
            canvas.SetActive(false);
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            i += 1;
        }
        if (settingin && Input.GetKeyDown(KeyCode.Q))
        {
            settingin = false;
            PauseeMenu.SetActive(true);
            setting.SetActive(false);
        }
    }

    public void ShowSetting()
    {
        setting.SetActive(true);
        PauseeMenu.SetActive(false);
        settingin = true;
    }

    public void Resume()
    {
        canvas.SetActive(false);
        Time.timeScale = 1;
    }
    public void Quit()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
