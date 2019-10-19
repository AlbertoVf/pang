﻿using Assets.Scripts;

using UnityEngine;

/// <summary>
/// Gestiona la escena principal del juego
/// </summary>
public class PressStart : MonoBehaviour
{
    public GameObject pressStart;

    /// <summary>
    /// The time
    /// </summary>
    private float time;

    /// <summary>
    /// Updates this instance.
    /// Carga la escena de modo de juego.
    /// </summary>
    private void Update()
    {
        ParpadeoTexto(pressStart);
        General.CargarEscena(1);
    }

    /// <summary>
    /// Parpadeo the texto.
    /// Hace parpadear al texto
    /// </summary>
    /// <param name="gm">The gm.</param>
    private void ParpadeoTexto(GameObject gm)
    {
        time += Time.deltaTime;
        if (Mathf.RoundToInt(time) % 2 == 0)
        {
            gm.SetActive(true);
        }
        else
        {
            gm.SetActive(false);
        }
    }
}