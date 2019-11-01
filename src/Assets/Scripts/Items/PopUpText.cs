using Assets.Scripts;

using UnityEngine;

/// <summary>
/// Gestiona el Texto de puntioacion al coger un item
/// </summary>
public class PopUpText : MonoBehaviour
{
    #region Public Fields

    /// <summary>
    /// The star position.
    /// Posicion en la que aparecera el texto.
    /// </summary>
    public Vector2 starPos;

    #endregion Public Fields

    #region Private Methods

    private void Start()
    {
        starPos = transform.position;
    }

    private void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * General.Tiempos["texto"]);
        if (transform.position.y > starPos.y + 2)
        {
            Destroy(gameObject);
        }
    }

    #endregion Private Methods
}