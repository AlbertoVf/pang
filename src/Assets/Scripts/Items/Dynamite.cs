using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamite : MonoBehaviour
{
    private bool inGround;

    // Update is called once per frame
    void Update()
    {
        if (!inGround)
        {
            transform.position += Vector3.down * Time.deltaTime * General.velocidades["lento"];
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            inGround = true;
            Destroy(gameObject, General.tiempo["item"]);
        }
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            BallManager.bm.Dynamite(5);
        }
    }
}
