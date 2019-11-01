using UnityEngine;

/// <summary>
/// Gestiona el item de frutas que permite aumentar la puntuacion
/// </summary>
public class Fruits : MonoBehaviour
{
    #region Public Fields

    /// <summary>
    /// The fruit item.
    /// Cada uno de los elementos del Array de frutas.
    /// </summary>
    public GameObject fruitItem;

    #endregion Public Fields

    #region Public Methods

    /// <summary>
    /// Instaciates the fruit.
    /// Crea una fruita en la posicion determinada. Donde explota la bola que lo genera
    /// </summary>
    public void InstaciateFruit()
    {
        Instantiate(fruitItem, transform.position, Quaternion.identity);
    }

    #endregion Public Methods
}