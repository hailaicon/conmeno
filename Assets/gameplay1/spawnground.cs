using System;
using UnityEngine;

public class spawnground : MonoBehaviour
{
    public GameObject ground;
    public Transform spawngd;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //xét collider để sinh ra đường bằng instantiate.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Instantiate(vật đc prefab, vị trí, xoay);
            GameObject go = Instantiate(ground, spawngd.position, Quaternion.identity);
            Destroy(this.gameObject, 6f);
        }
    }
}
