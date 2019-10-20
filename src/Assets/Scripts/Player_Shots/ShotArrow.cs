using Assets.Scripts;

using UnityEngine;

/// <summary>
/// Gestiona la flecha
/// </summary>
public class ShotArrow : MonoBehaviour
{
    /// <summary>
    /// The chain GFX
    /// Grafico de la cadena
    /// </summary>
    public GameObject chainGFX;

    /// <summary>
    /// The speed
    /// Velocidad del disparo
    /// </summary>
    private float speed = General.Velocidades["normal"];

    /// <summary>
    /// The start position
    /// </summary>
    private Vector2 startPos;

    /// <summary>
    /// Starts this instance.
    /// </summary>
    private void Start()
    {
        startPos = transform.position;
        DibujarCadena();
    }

    /// <summary>
    /// Updates this instance.
    /// Actualiza la flecha
    /// </summary>
    private void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
        if ((transform.position.y - startPos.y) >= 0.2f)
        {
            DibujarCadena();
            startPos = transform.position;
        }
    }

    /// <summary>
    /// Called when [trigger enter2 d].
    /// Destruye una bola al colisionar con ella
    /// </summary>
    /// <param name="collision">The collision.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            collision.gameObject.GetComponent<Ball>().Split();
        }
        if (collision.gameObject.tag != "Player")
        {
            Destroy(gameObject);
            ShotManager.shm.DestroyShot();
        }
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