using Assets.Scripts;
using UnityEngine;

public class ShotGun : MonoBehaviour
{
    float speed = General.velocidades["rapido"];

    // Update is called once per frame
    void Update()
    {
        if (transform.rotation.z == 0)
        {
            transform.position += Vector3.up * Time.deltaTime * speed;
        }
        else if (transform.rotation.z < 0)
        {
            transform.position += new Vector3(0.1f, 1) * Time.deltaTime * speed;
        }
        else if (transform.rotation.z > 0)
        {
            transform.position += new Vector3(-0.1f, 1) * Time.deltaTime * speed;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        ShotManager.shm.DestroyShot();
    }
}
