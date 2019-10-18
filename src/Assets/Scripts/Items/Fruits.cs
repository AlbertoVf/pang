using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{
    public GameObject fruitItem;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            InstaciateFruit();
        }
    }

    public void InstaciateFruit()
    {
        Instantiate(fruitItem, transform.position,Quaternion.identity);
    }
}
