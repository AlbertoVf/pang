using UnityEngine;

/// <summary>
/// Gestiona el diseño de la cadena
/// </summary>
public class ChainGFX : MonoBehaviour
{
    #region Private Fields

    /// <summary>
    /// The start position.
    /// </summary>
    private Vector2 startPos;

    #endregion Private Fields

    #region Private Methods

    /// <summary>
    /// Starts this instance.
    /// Asigna la posicion inicial.
    /// </summary>
    private void Start()
    {
        startPos = transform.position;
    }

    /// <summary>
    /// Updates this instance.
    /// Actualiza la posicion.
    /// </summary>
    private void Update()
    {
        transform.position = startPos;
    }

    #endregion Private Methods
}