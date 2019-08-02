using System.Collections.Generic;
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
            ["derecha"] = KeyCode.RightArrow,
            ["izquierda"] = KeyCode.LeftArrow,
            ["disparar"] = KeyCode.Space
        };

        /// <summary>
        /// Limites de la pantalla para el mvimiento del jugador
        /// </summary>
        public static Dictionary<string, float> limites = new Dictionary<string, float>
        {
            ["izquierda"] = -8.24f,
            ["derecha"] = 8.24f,
            ["superior"] = 4.13f,
            ["inferior"] = -2.57f
        };

        /// <summary>
        /// Velocidades de los proyectiles y el jugador
        /// </summary>
        public static Dictionary<string, float> velocidades = new Dictionary<string, float>
        {
            ["nulo"] = 0f,
            ["desaparicion"] = 0.4f,
            ["lento"] = 2f,
            ["normal"] = 4f,
            ["rapido"] = 6f
        };

        /// <summary>
        /// Carga una escena al presionar la tecla enter
        /// </summary>
        /// <param name="escena">Nombre de la escena</param>
        public static void CargarEscena(string escena)
        {
            if (Input.GetKeyDown(teclas["start"]))
            {
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
                SceneManager.LoadScene(escena);
            }
        }
    }
}
