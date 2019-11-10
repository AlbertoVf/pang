using Assets.Scripts;

using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/// <summary>
/// Gestiona el ancla
/// </summary>
public class ShotAncle : MonoBehaviour
{
    #region Public Fields

    /// <summary>
    /// The chain GFX
    /// Diseño de la cadena
    /// </summary>
    public GameObject chainGFX;

    #endregion Public Fields

    #region Private Fields

    /// <summary>
    /// The chains
    /// Eslavones de la cadena
    /// </summary>
    private List<GameObject> chains = new List<GameObject>();

    /// <summary>
    /// The speed
    /// Velocidad del ancla
    /// </summary>
    private float speed = Velocidad.NORMAL;

    /// <summary>
    /// The start position
    /// </summary>
    private Vector2 startPos;

    #endregion Private Fields

    #region Private Methods

    /// <summary>
    /// Modifica el grafico de la cadena añadiendo los eslabones superpuestos al blanco
    /// </summary>
    private void DibujarCadena()
    {
        GameObject chain = Instantiate(chainGFX, transform.position - new Vector3(0, 0.2f, 0), Quaternion.identity);
        chain.transform.parent = transform;
        chains.Add(chain);
    }

    /// <summary>
    /// Corrutina que dispara el ancla y al colisionar con el techo cambia de color y desaparece en un tiempo determinado
    /// </summary>
    /// <returns>Desaparicion de ancla tras un tiempo determinado</returns>
    private IEnumerator IEDestroyAncle()
    {
        Color color = Color.red;
        speed = Velocidad.NULO;
        yield return new WaitForSeconds(TiempoEspera.ANCLA);
        GetComponentInParent<SpriteRenderer>().color = color;
        foreach (GameObject item in chains)
        {
            item.GetComponent<SpriteRenderer>().color = color;
        }
        yield return new WaitForSeconds(TiempoEspera.ANCLA);
        Destroy(gameObject);
        ShotManager.shm.DestroyShot();
    }

    /// <summary>
    /// Called when [trigger enter2 d].
    /// Al colisionar con el techo cambia de color y al colisionar con la bola la destruye
    /// </summary>
    /// <param name="collision">The collision.</param>
    private void OnTriggerEnter2D(Collider2D collision)
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
    /// Starts this instance.
    /// Realiza el disparo
    /// </summary>
    private void Start()
    {
        startPos = transform.position;
        DibujarCadena();
    }

    private void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
        if ((transform.position.y - startPos.y) >= 0.2f)
        {
            DibujarCadena();
            startPos = transform.position;
        }
    }

    #endregion Private Methods
}