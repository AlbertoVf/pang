using Assets.Scripts;

using UnityEngine;

/// <summary>
/// Gestiona el recorrido de la cadena en el disparo de flecha y ancla.
/// </summary>
public class Chain : MonoBehaviour
{
    /// <summary>
    /// Updates this instance.
    /// Crea el recorrido de la cadena a la velocidad de la flecha/ancla.
    /// </summary>
    private void Update()
    {
        if (transform.localScale.y < 7f)
        {
            transform.localScale += Vector3.up * Time.deltaTime * General.Velocidades["normal"];
        }
    }
}