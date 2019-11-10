using Assets.Scripts;

using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Gestiona la escena de seleccion de modo de juego
/// </summary>
public class SelectMode : MonoBehaviour
{
    #region Public Fields

    /// <summary>
    /// The panic mode image.
    /// </summary>
    public Image panicModeImage;

    /// <summary>
    /// The panic mode text
    /// </summary>
    public Text panicModeText;

    /// <summary>
    /// The tour mode image
    /// </summary>
    public Image tourModeImage;

    /// <summary>
    /// The tour mode text
    /// </summary>
    public Text tourModeText;

    #endregion Public Fields

    #region Private Fields

    /// <summary>
    /// The tour.
    /// Indica si esta seleccionado el modo Tour
    /// </summary>
    private bool tour;

    #endregion Private Fields

    #region Private Methods

    private void Start()
    {
        tour = true;
    }

    /// <summary>
    /// Updates this instance.
    /// Cambia el color del modo de juego seleccionado
    /// </summary>
    private void Update()
    {
        if (tour)
        {
            tourModeImage.color = new Color(1, 1, 1);
            tourModeText.color = new Color(1, 1, 1);

            panicModeImage.color = new Color(1, 1, 0, 0.5f);
            panicModeText.color = new Color(1, 1, 1, 0.5f);

            if (Input.GetKeyDown(Tecla.IZQUIERDA))
            {
                tour = false;
            }
            General.g.CargarEscena("TourMode_01");
        }
        else
        {
            panicModeImage.color = new Color(1, 1, 1);
            panicModeText.color = new Color(1, 1, 1);

            tourModeImage.color = new Color(1, 1, 0, 0.5f);
            tourModeText.color = new Color(1, 1, 1, 0.5f);

            if (Input.GetKeyDown(Tecla.DERECHA))
            {
                tour = true;
            }
            General.g.CargarEscena("PanicMode");
        }
    }

    #endregion Private Methods
}