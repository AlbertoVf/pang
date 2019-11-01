using UnityEngine;

public class CurrentShotImage : MonoBehaviour
{
    #region Public Fields

    /// <summary>
    /// The ancle shot
    /// </summary>
    public GameObject ancleShot;

    /// <summary>
    /// The arrow shot
    /// </summary>
    public GameObject arrowShot;

    /// <summary>
    /// The gun shot
    /// </summary>
    public GameObject gunShot;

    #endregion Public Fields

    #region Public Methods

    /// <summary>
    /// Currents the shot.
    /// Dibuja la imagen del disparo actual.
    /// </summary>
    /// <param name="shot">The shot.</param>
    public void CurrentShot(string shot)
    {
        if (shot.Equals("Arrow"))
        {
            Desactivar(true, false, false);
        }
        else if (shot.Equals("Ancle"))
        {
            Desactivar(false, true, false);
        }
        else if (shot.Equals("Gun"))
        {
            Desactivar(false, false, true);
        }
        else
        {
            Desactivar(false, false, false);
        }
    }

    #endregion Public Methods

    #region Private Methods

    /// <summary>
    /// Desactivars the specified a.
    /// Establece que disparo se mostrara
    /// </summary>
    /// <param name="a">if set to <c>true</c>Muestra la imagen de dobleArrow</param>
    /// <param name="an">if set to <c>true</c> Muestra la imagen de ancle</param>
    /// <param name="g">if set to <c>true</c> Muestra la imagen de shot</param>
    private void Desactivar(bool a, bool an, bool g)
    {
        arrowShot.SetActive(a);
        ancleShot.SetActive(an);
        gunShot.SetActive(g);
    }

    #endregion Private Methods
}