using Assets.Scripts;

using UnityEngine;

/// <summary>
/// Gestiona los disparos de la escopeta
/// </summary>
public class ShotGun : MonoBehaviour
{
    #region Private Fields

    /// <summary>
    /// The speed.
    /// Velocidad de los disparos
    /// </summary>
    private readonly float speed = General.Velocidades["rapido"];

    #endregion Private Fields

    #region Private Methods

    /// <summary>
    /// Called when [trigger enter2 d].
    /// Comprueba si colisiono con la bola o con un objeto distinto de jugador
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
    /// Updates this instance.
    /// Dispara las 3 balas en diferentes direcciones
    /// </summary>
    private void Update()
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

    #endregion Private Methods
}