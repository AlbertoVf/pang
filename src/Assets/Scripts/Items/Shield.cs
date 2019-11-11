using Assets.Scripts;

using UnityEngine;

/// <summary>
/// Gestiona el item de escudo
/// </summary>
public class Shield : MonoBehaviour
{
    #region Private Fields

    /// <summary>
    /// The in ground. Comprueba si esta en el suelo
    /// </summary>
    private bool inGround;

    #endregion Private Fields

    #region Private Methods

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
            Destroy(gameObject, Tiempo.ITEMSUELO);
        }
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().shield.SetActive(true);
            collision.gameObject.GetComponent<Player>().blink = false;
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Updates this instance.
    /// Realiza la caida del objeto hasta el suelo
    /// </summary>
    private void Update()
    {
        if (!inGround)
        {
            transform.position += Vector3.down * Time.deltaTime * Velocidad.LENTO;
        }
    }

    #endregion Private Methods
}