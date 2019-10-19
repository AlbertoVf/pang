using UnityEngine;

/// <summary>
/// Gestiona el item de frutas que permite aumentar la puntuacion
/// </summary>
public class Fruits : MonoBehaviour
{
    /// <summary>
    /// The fruit item.
    /// Cada uno de los elementos del Array de frutas.
    /// </summary>
    public GameObject fruitItem;

    /// <summary>
    /// Instaciates the fruit.
    /// Crea una fruita en la posicion determinada. Donde explota la bola que lo genera
    /// </summary>
    public void InstaciateFruit()
    {
        Instantiate(fruitItem, transform.position, Quaternion.identity);
    }
}