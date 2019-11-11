using Assets.Scripts;

using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Gestiona la escena de seleccion de modo de juego
/// </summary>
public class SelectMode : MonoBehaviour
{
    #region Public Fields

    public AudioClip click;

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

    private AudioSource fuenteAudio;

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
        fuenteAudio = GetComponent<AudioSource>();
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
            General.CargarEscena("TourMode_01");
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
            // General.CargarEscena("PanicMode");
        }
        General.AudioClick(fuenteAudio, click);
    }

    #endregion Private Methods
}