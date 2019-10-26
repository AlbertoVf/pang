using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentShotImage : MonoBehaviour
{
    /// <summary>
    /// The arrow shot
    /// </summary>
    public GameObject arrowShot;
    /// <summary>
    /// The ancle shot
    /// </summary>
    public GameObject ancleShot;
    /// <summary>
    /// The gun shot
    /// </summary>
    public GameObject gunShot;

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
        }else if (shot.Equals("Ancle"))
        {
            Desactivar(false, true, false);
        }else if (shot.Equals("Gun"))
        {
            Desactivar(false, false, true);
        }
        else
        {
            Desactivar(false, false, false);
        }
    }

    /// <summary>
    /// Desactivars the specified a.
    /// Establece que disparo se mostrara
    /// </summary>
    /// <param name="a">if set to <c>true</c>Muestra la imagen de dobleArrow</param>
    /// <param name="an">if set to <c>true</c> Muestra la imagen de ancle</param>
    /// <param name="g">if set to <c>true</c> Muestra la imagen de shot</param>
    void Desactivar(bool a, bool an, bool g)
    {
        arrowShot.SetActive(a);
        ancleShot.SetActive(an);
        gunShot.SetActive(g);
    }
}
