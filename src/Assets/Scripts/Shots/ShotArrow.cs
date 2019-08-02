using Assets.Scripts;
using UnityEngine;

public class ShotArrow : MonoBehaviour
{
    float speed = General.velocidades["normal"];
    public GameObject chainGFX;
    Vector2 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        DibujarCadena();
        //startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
        if ((transform.position.y - startPos.y) >= 0.2f)
        {
            DibujarCadena();
            startPos = transform.position; 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        ShotManager.shm.DestroyShot();
    }

    /// <summary>
    /// Modifica el grafico de la cadena añadiendo los eslabones superpuestos al blanco
    /// </summary>
    private void DibujarCadena()
    {
        GameObject chain = Instantiate(chainGFX, transform.position - new Vector3(0, 0.2f, 0), Quaternion.identity);
        chain.transform.parent = transform;
    }
}
