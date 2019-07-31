using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    class General
    {
        /// <summary>
        /// Gestiona las teclas que se utilizaran en el juego:
        /// 0: enter
        /// 1: flecha izquierda
        /// 2: flecha derecha
        /// </summary>
        public static KeyCode[] teclas = { KeyCode.Return, KeyCode.RightArrow, KeyCode.LeftArrow };

        /// <summary>
        /// Carga una escena al presionar la tecla enter
        /// </summary>
        /// <param name="escena">Nombre de la escena</param>
        public static void CargarEscena(string escena)
        {
            if (Input.GetKeyDown(General.teclas[0]))
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
            if (Input.GetKeyDown(General.teclas[0]))
            {
                //Crear escena para modo Aventura
                SceneManager.LoadScene(escena);
            }
        }
    }
}
