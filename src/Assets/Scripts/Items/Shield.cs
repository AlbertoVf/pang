using Assets.Scripts;

using UnityEngine;

/// <summary>
/// Gestiona el item de escudo
/// </summary>
public class Shield : MonoBehaviour
{
    /// <summary>
    /// The in ground. Comprueba si esta en el suelo
    /// </summary>
    private bool inGround;

    private void Update()
    {
        if (!inGround)
        {
            transform.position += Vector3.down * Time.deltaTime * General.Velocidades["lento"];
        }
    }

    /// <summary>
    /// Called when [trigger enter2 d].
    /// Comprueba si colisiono con el suelo o con el jugador
    /// </summary>
    /// <param name="collision">The collision.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            inGround = true;
            Destroy(gameObject, General.Tiempos["item"]);
        }
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().shield.SetActive(true);
            collision.gameObject.GetComponent<Player>().blink = false;
            Destroy(gameObject);
        }
    }
}