using UnityEngine;

/// <summary>
/// Gestiona los objetos de las escenas que se conservaran para la siguiente
/// </summary>
public class Estatico : MonoBehaviour
{
    #region Public Fields

    public static Estatico e;

    #endregion Public Fields

    #region Private Methods

    /// <summary>
    /// Awakes this instance.
    /// </summary>
    private void Awake()
    {
        if (e == null)
        {
            e = this;
        }
        else if (e != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    #endregion Private Methods
}