using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class ShotAncle : MonoBehaviour
{
    float speed = General.velocidades["normal"];
    public GameObject chainGFX;
    Vector2 startPos;
    List<GameObject> chains = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        DibujarCadena();
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

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Roof")
        {
            StartCoroutine(IEDestroyAncle());
        }
        if (collision.gameObject.tag == "Ball")
        {
            collision.gameObject.GetComponent<Ball>().Split();
            Destroy(gameObject);
            ShotManager.shm.DestroyShot();
        }
    }

    /// <summary>
    /// Modifica el grafico de la cadena añadiendo los eslabones superpuestos al blanco
    /// </summary>
    void DibujarCadena()
    {
        GameObject chain = Instantiate(chainGFX, transform.position - new Vector3(0, 0.2f, 0), Quaternion.identity);
        chain.transform.parent = transform;
        chains.Add(chain);
    }

    /// <summary>
    /// Corrutina que dispara el ancla y al colisionar con el techo cambia de color y desaparece en un tiempo determinado
    /// </summary>
    /// <returns>Desaparicion de ancla tras un tiempo determinado</returns>
    IEnumerator IEDestroyAncle()
    {
        Color color = Color.red;
        speed = General.velocidades["nulo"];
        yield return new WaitForSeconds(General.velocidades["desaparicion"]);
        GetComponentInParent<SpriteRenderer>().color = color;
        foreach (GameObject item in chains)
        {
            item.GetComponent<SpriteRenderer>().color = color;
        }
        yield return new WaitForSeconds(General.velocidades["desaparicion"]);
        Destroy(gameObject);
        ShotManager.shm.DestroyShot();
    }
}
