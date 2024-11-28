using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class danhno : MonoBehaviour
{
    public danhvabidanh p1;
    public danhvabidanh p2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // nhấn để đánh.
        if (Input.GetKeyDown(KeyCode.J))
        {
            p1danh();
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            p2danh();
        }
    }

    //hàm đánh.
    public void p1danh()
    {
        p1.deadamage(p2.gameObject);
        Debug.Log("p1 hit p2");
    }
    public void p2danh()
    {
        p2.deadamage(p1.gameObject);
        Debug.Log("p2 hit p1");
    }
}
