using System.Collections;

using UnityEngine;

/// <summary>
/// Manager para gestionar el inicio de partida en cada nivel
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// The gm
    /// Variable para haceder a la clase desde otras
    /// </summary>
    public static GameManager gm;

    /// <summary>
    /// Awakes this instance.
    /// Establece la variable estatica de clase
    /// </summary>
    private void Awake()
    {
        if (gm == null)
        {
            gm = this;
        }
        else if (gm != null)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Ies the game start.
    /// Inicia el nivel
    /// </summary>
    /// <returns></returns>
    public IEnumerator IEGameStart()
    {
        yield return null;
    }

    /// <summary>
    /// Ies the ready.
    /// Inicia la partida
    /// </summary>
    /// <returns></returns>
    public IEnumerator IEReady()
    {
        StartCoroutine(IEGameStart());
        yield return null;
    }
}