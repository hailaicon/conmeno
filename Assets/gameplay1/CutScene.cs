using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScene : MonoBehaviour
{
    public bool Scene;
    public float time = 8.5f;
    public float times = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            //SceneManager.LoadScene("gameplay1");
            Scene = true;
        }
        times -= Time.deltaTime;
        if (times <= 0)
        {
            //SceneManager.LoadScene("gameplay2");
            Scene= false;
        }
        if (Scene)
        {
            SceneManager.LoadScene("gameplay1");
        }
        else
        {
            SceneManager.LoadScene("gameplay2");
        }
    }

}
