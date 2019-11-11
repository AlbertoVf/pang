using Assets.Scripts;

using System.Collections;

using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Gestionar el borde del nivel
/// </summary>
public class BorderColor : MonoBehaviour
{
    #region Private Fields

    /// <summary>
    /// The border color
    /// </summary>
    private Image borderColor;

    /// <summary>
    /// The danger
    /// </summary>
    private bool danger;

    /// <summary>
    /// The danger color
    /// Color del borde cuando se esta acabando el tiempo
    /// </summary>
    private Color dangerColor = new Color((231f / 255), (60f / 255), (42f / 255));//rojo

    /// <summary>
    /// The normal color
    /// </summary>
    private Color normalColor;

    /// <summary>
    /// The time
    /// </summary>
    private float time;

    #endregion Private Fields

    #region Private Methods

    /// <summary>
    /// Awakes this instance.
    /// </summary>
    private void Awake()
    {
        borderColor = GetComponent<Image>();
    }

    /// <summary>
    /// Ies the danger.
    /// Cambia el color del borde
    /// </summary>
    /// <returns></returns>
    private IEnumerator IEDanger()
    {
        danger = true;
        while (time > 0)
        {
            if (borderColor.color == normalColor)
            {
                borderColor.color = dangerColor;
            }
            else
            {
                borderColor.color = normalColor;
            }
            yield return new WaitForSeconds(TiempoEspera.NORMAL);
        }
    }

    /// <summary>
    /// Starts this instance.
    /// </summary>
    private void Start()
    {
        normalColor = borderColor.color;
    }

    /// <summary>
    /// Updates this instance.
    /// Inicia el cambio de color al llegar al limite de tiempo
    /// </summary>
    private void Update()
    {
        time = GameManager.gm.time;
        if (time <= 10 && !danger)
        {
            StartCoroutine(IEDanger());
        }
    }

    #endregion Private Methods
}