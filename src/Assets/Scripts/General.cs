﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    class General
    {
        /// <summary>
        /// Gestiona las teclas que se utilizaran en el juego
        /// </summary>
        public static Dictionary<string, KeyCode> teclas = new Dictionary<string, KeyCode>
        {
            ["start"] = KeyCode.Return,
            ["izquierda"] = KeyCode.RightArrow,
            ["derecha"] = KeyCode.LeftArrow
        };

        /// <summary>
        /// Limites de la pantalla para el mvimiento del jugador
        /// </summary>
        public static Dictionary<string,float> limites = new Dictionary<string, float>
        {
            ["izquierda"] = -8.1f,
            ["derecha"] = 8.19f,
            ["superior"]=4.13f,
            ["inferior"]=-2.51f
        };
        /// <summary>
        /// Carga una escena al presionar la tecla enter
        /// </summary>
        /// <param name="escena">Nombre de la escena</param>
        public static void CargarEscena(string escena)
        {
            if (Input.GetKeyDown(teclas["start"]))
            {
                //Crear escena para modo Aventura
                SceneManager.LoadScene(escena);
            }
        }
        /// <summary>
        /// Carga una escena al presionar la tecla enter
        /// </summary>
        /// <param name="escena">Numero de la escena</param>
        public static void CargarEscena(int escena)
        {
            if (Input.GetKeyDown(teclas["start"]))
            {
                //Crear escena para modo Aventura
                SceneManager.LoadScene(escena);
            }
        }
    }
}
