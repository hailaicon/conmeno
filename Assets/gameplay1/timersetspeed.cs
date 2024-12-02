using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class timersetspeed : MonoBehaviour
{
    public player p1;
    public float timer = 0f;
    public bool tang = true;
    // Start is called before the first frame update
    void Start()
    {
        p1 = FindObjectOfType<player>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 10f && timer < 50f && tang)
        {
            p1.speed += 2;
            tang = false;
        }
        else if(timer > 50f && timer < 100f && !tang)
        {
            p1.speed += 5;
            tang = true;
        }
        else if(timer > 100f && timer < 200f && tang)
        {
            p1.speed += 10;
            tang = false;
        }
    }
}