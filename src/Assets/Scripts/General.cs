using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    /// <summary>
    /// Gestiona todas las variables estaticas del juego. Cambio de escenas, teclas de juego, velocidades, tiempo, limites...
    /// </summary>
    internal class General
    {
        /// <summary>
        /// The escala gravedad. Escala de gravedad de los objetos. La gravedad por defecto es de (-9.81f)
        /// baja : la gravedad es la mitad
        /// normal : no se modifica la gravedad
        /// alta : la gravedad es el doble
        /// </summary>
        public static Dictionary<string, float> EscalasGravedad = new Dictionary<string, float>
        {
            ["baja"] = 0.5f,
            ["normal"] = 1f,
            ["alta"] = 2f
        };

        /// <summary>
        /// Gestiona las teclas que se utilizaran en el juego.
        /// </summary>
        public static Dictionary<string, KeyCode> Teclas = new Dictionary<string, KeyCode>
        {
            ["start"] = KeyCode.Return,
            ["derecha"] = KeyCode.RightArrow,
            ["izquierda"] = KeyCode.LeftArrow,
            ["disparar"] = KeyCode.Space
        };

        /// <summary>
        /// Limites de la pantalla para el movimiento del jugador.
        /// </summary>
        public static Dictionary<string, float> Limites = new Dictionary<string, float>
        {
            ["izquierda"] = -8.24f,
            ["derecha"] = 8.24f,
            ["superior"] = 4.13f,
            ["inferior"] = -2.57f
        };

        /// <summary>
        /// Puntuaciones del juego.
        /// inicial : puntuacion al comenzar una nueva partida
        /// actual : puntuacion durante la partida
        /// record : puntuacion maxima alcanzada
        /// bola : puntuacion al romper una bola
        /// fruit : puntuacion al coger un item de fruta
        /// item : puntuacion al coger un arma, oscudo u objeto
        /// </summary>
        public static Dictionary<string, int> Puntuaciones = new Dictionary<string, int>
        {
            ["inicial"] = 0,
            ["actual"] = 0,
            ["record"] = 0,
            ["bola"] = Aleatorio(200,500),
            ["fruit"] = Aleatorio(300,1000),
            ["item"] = Aleatorio(100,300)
        };

        /// <summary>
        /// Tiempos de duracion en segundos.
        /// item : Duracion de los items en el suelo.
        /// cuentaAtras : temporizador de inicio,duracion de perdida de escudo, ralentizacion de reloj
        /// parpadeo : parpadeo de las animaciones.
        /// texto : duracion del texto de puntuacion de frutas y bolas, espera al perder la partida
        /// partida : duracion del nivel
        /// </summary>
        public static Dictionary<string, float> Tiempos = new Dictionary<string, float>
        {
            ["item"] = 3f,
            ["cuentaAtras"] = 2f,
            ["parpadeo"] = 0.2f,
            ["texto"] = 1f,
            ["partida"] = 100f
        };

        /// <summary>
        /// Velocidades de los proyectiles y el jugador.
        /// </summary>
        public static Dictionary<string, float> Velocidades = new Dictionary<string, float>
        {
            ["nulo"] = 0f,
            ["desaparicion"] = 0.4f,
            ["muyLento"] = 1.3f,
            ["lento"] = 2.5f,
            ["normal"] = 4f,
            ["rapido"] = 6f,
            ["muyRapido"] = 8f
        };

        /// <summary>
        /// Carga una escena al presionar la tecla enter.
        /// </summary>
        /// <param name="escena">Nombre de la escena</param>
        public static void CargarEscena(string escena)
        {
            if (Input.GetKeyDown(Teclas["start"]))
            {
                SceneManager.LoadScene(escena);
            }
        }

        /// <summary>
        /// Carga una escena al presionar la tecla enter.
        /// </summary>
        /// <param name="escena">Numero de la escena</param>
        public static void CargarEscena(int escena)
        {
            if (Input.GetKeyDown(Teclas["start"]))
            {
                SceneManager.LoadScene(escena);
            }
        }
        /// <summary>
        /// Genera un numero aleatorio entre dos valores, ambos incluidos
        /// </summary>
        /// <param name="min">Valor minimo</param>
        /// <param name="max">Valor maximo</param>
        /// <returns>Numero</returns>
        static int Aleatorio(int min, int max)
        {
            System.Random r = new System.Random();
            int a = r.Next(min, max+1);
            return a;
        }
    }
}