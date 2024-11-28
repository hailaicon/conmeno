using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class danhvabidanh : MonoBehaviour
{
    public int health;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //tạo hàm mất máu. 
    public void takedamage(int amout)
    {
        health -= amout;
    }

    //tạo hàm gây damage.
    public void deadamage(GameObject target)
    {
        var atm = target.GetComponent<danhvabidanh>();
        atm.takedamage(damage);
    }
}
