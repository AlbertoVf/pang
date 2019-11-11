using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// controlar el fondo del escenario
/// </summary>
public class BackgroundChange : MonoBehaviour
{
    #region Public Fields

    /// <summary>
    /// The backgrounds
    /// </summary>
    public Sprite[] backgrounds;

    #endregion Public Fields

    #region Private Fields

    /// <summary>
    /// The current background
    /// </summary>
    private Image currentBackground;

    #endregion Private Fields

    #region Private Methods

    /// <summary>
    /// Starts this instance.
    /// Selecciona un fondo aleatorio
    /// </summary>
    private void Start()
    {
        currentBackground = GetComponent<Image>();
        currentBackground.sprite = backgrounds[Random.Range(0, backgrounds.Length)];
    }

    #endregion Private Methods
}