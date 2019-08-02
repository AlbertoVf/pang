using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainGFX : MonoBehaviour
{
    Vector2 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startPos;
    }
}
