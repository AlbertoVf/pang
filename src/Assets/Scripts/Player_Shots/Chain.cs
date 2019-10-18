using Assets.Scripts;
using UnityEngine;

public class Chain : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.y < 7f)
        {
            transform.localScale += Vector3.up * Time.deltaTime * General.velocidades["normal"];
        }
    }
}
