using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class enemyenergy : MonoBehaviour
{
    public Slider manaslider;
    public int mana = 100;
    // Start is called before the first frame update
    void Start()
    {
        //chạy coroutine tên manathief.
        StartCoroutine(manathief());
    }

    // Update is called once per frame
    void Update()
    {
        manaslider.value = mana;
        //mana nhỏ hơn hoặc bằng thì chuyển scene khác.
        if (mana <= 0) SceneManager.LoadScene("cutscene2");

    }
    //chạy Ie để kiểm soát thời gian
    IEnumerator manathief()
    {
        while(mana <= 100)
        {   
            yield return new WaitForSeconds(0.5f);
            mana -= 1;
        }
    }
}
