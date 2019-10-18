using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpText : MonoBehaviour
{
    public Vector2 starPos;
    // Start is called before the first frame update
    void Start()
    {
        starPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * General.tiempos["texto"]);
        if(transform.position.y > starPos.y + 2)
        {
            Destroy(gameObject);
        }
    }
}
