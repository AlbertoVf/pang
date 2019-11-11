using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    /// <summary>
    ///  Escala de gravedad de los objetos. La gravedad por defecto es de (-9.81f)
    /// </summary>
    public class Gravedad
    {
        #region Public Fields

        /// <summary>
        /// The alta
        /// La gravedad se multiplica x2
        /// </summary>
        public const float ALTA = 2f;

        /// <summary>
        /// The baja
        /// La gravedad se multiplica x0.5
        /// </summary>
        public const float BAJA = 0.5f;

        /// <summary>
        /// The normal
        /// Gravedad por defecto (-9.81f)
        /// </summary>
        public const float NORMAL = 1F;

        #endregion Public Fields
    }

    /// <summary>
    /// Puntuacion durante las partidas.
    /// </summary>
    public class Puntuacion
    {
        #region Public Fields

        /// <summary>
        /// The actual
        /// Puntuacion actual del jugador
        /// </summary>
        public const int ACTUAL = 0;

        /// <summary>
        /// The bola
        /// Puntuacion que se consigue al romper una bola
        /// </summary>
        public const int BOLA = 512;

        /// <summary>
        /// The fruit
        /// Puntuacion que se consigue al coger una fruta
        /// </summary>
        public const int FRUIT = 1024;

        /// <summary>
        /// The inicial
        /// Puntuacion inicial del nivel
        /// </summary>
        public const int INICIAL = 0;

        /// <summary>
        /// The item
        /// Puntuacion que se consigue al coger un disparo, escudo, dinamita o vida extra
        /// </summary>
        public const int ITEM = 128;

        /// <summary>
        /// The vida
        /// Numero de vidas con las que se comienza
        /// </summary>
        public const int VIDA = 3;

        #endregion Public Fields
    }

    /// <summary>
    /// Puntuacion durante el recuento de puntos. Son puntos extra
    /// </summary>
    public class PuntuacionRecuento
    {
        #region Public Fields

        /// <summary>
        /// The bola
        /// Puntuacion que da cada bola durante el recuento
        /// </summary>
        public const int BOLA = 32;

        /// <summary>
        /// The fruitPuntuacion que da cada frua durante el recuento
        /// </summary>
        public const int FRUIT = 64;

        /// <summary>
        /// The tiempo
        /// Puntuacion que se recibe por cada segundo que sobra del nivel
        /// </summary>
        public const int TIEMPO = 16;

        #endregion Public Fields
    }

    /// <summary>
    /// Gestiona las teclas que se utilizaran en el juego.
    /// </summary>
    public class Tecla
    {
        #region Public Fields

        /// <summary>
        /// The derecha
        /// Tecla para realizar un movimiento a la derecha
        /// </summary>
        public const KeyCode DERECHA = KeyCode.RightArrow;

        /// <summary>
        /// The disparar
        /// Tecla para realizar un disparo
        /// </summary>
        public const KeyCode DISPARAR = KeyCode.Space;

        /// <summary>
        /// The izquierda
        /// Tecla para realizar un movimiento a la izquierda
        /// </summary>
        public const KeyCode IZQUIERDA = KeyCode.LeftArrow;

        /// <summary>
        /// The pausa
        /// Tecla para realizar una pausa durante la partida
        /// </summary>
        public const KeyCode PAUSA = KeyCode.Return;

        /// <summary>
        /// The start
        /// Tecla para seleccionar un modo de juego o avanzar entre pantallas de menu
        /// </summary>
        public const KeyCode START = KeyCode.Return;

        #endregion Public Fields
    }

    /// <summary>
    /// Tiempos de duracion en segundos.
    /// </summary>
    public class Tiempo
    {
        #region Public Fields

        /// <summary>
        /// The congelacion
        /// Duracion de la congelacion al coger el relog de arena
        /// </summary>
        public const float CONGELACION = 6f;

        /// <summary>
        /// The cuentaatras
        /// Tiempo desde que se muestra el nivel hasta que inicia la partida
        /// </summary>
        public const float CUENTAATRAS = 3f;

        /// <summary>
        /// The itemsuelo
        /// Duracion del item en el suelo
        /// </summary>
        public const float ITEMSUELO = 3f;

        /// <summary>
        /// The parpadeo
        /// Duracion del parpadeo al perder el escudo
        /// </summary>
        public const float PARPADEO = 0.3f;

        /// <summary>
        /// The partida
        /// Duracion de la partida
        /// </summary>
        public const float PARTIDA = 100f;

        /// <summary>
        /// The texto
        /// Duracion del texto con la puntuacion
        /// </summary>
        public const float TEXTO = 1f;

        #endregion Public Fields
    }

    /// <summary>
    /// Tiempos de espera en segundos
    /// </summary>
    public class TiempoEspera
    {
        #region Public Fields

        /// <summary>
        /// The ancla
        /// Tiempo que dura la cadena del ancla en el techo
        /// </summary>
        public const float ANCLA = 0.5f;

        /// <summary>
        /// The gameover
        /// Duracion del texto de game over
        /// </summary>
        public const float GAMEOVER = 1f;

        public const float LARGA = 1f;
        public const float NORMAL = 0.5f;
        public const float RAPIDA = 0.15f;

        #endregion Public Fields
    }

    /// <summary>
    /// Velocidades de los proyectiles y del jugador.
    /// </summary>
    public class Velocidad
    {
        #region Public Fields

        public const float LENTO = 2.5f;
        public const float MUYLENTO = 1.3f;
        public const float MUYRAPIDO = 8f;
        public const float NORMAL = 4f;
        public const float NULO = 0f;
        public const float RAPIDO = 6f;

        #endregion Public Fields
    }

    /// <summary>
    /// Gestiona todas las variables estaticas del juego. Cambio de escenas, teclas de juego, velocidades, tiempo, limites...
    /// </summary>
    internal class General
    {
        #region Public Methods

        /// <summary>
        /// Audioes the specified fuente.
        /// Establece una pista de sonido cuando ocurren colisiones
        /// </summary>
        /// <param name="fuente">The fuente.</param>
        /// <param name="sonido">The sonido.</param>
        public static void Audio(AudioSource fuente, AudioClip sonido)
        {
            fuente.clip = sonido;
            fuente.Play();
        }

        /// <summary>
        /// Audioes the click.
        /// Establece un sonido cuando se pulsa una tecla
        /// </summary>
        /// <param name="fuente">The fuente.</param>
        /// <param name="sonido">The sonido.</param>
        /// <param name="k">The k.</param>
        public static void AudioClick(AudioSource fuente, AudioClip sonido, KeyCode k = Tecla.START)
        {
            if (Input.GetKeyDown(k))
            {
                fuente.clip = sonido;
                fuente.Play();
            }
        }

        /// <summary>
        /// Carga una escena al presionar la tecla enter.
        /// </summary>
        /// <param name="escena">Nombre de la escena</param>
        public static void CargarEscena(string escena)
        {
            if (Input.GetKeyDown(Tecla.START))
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
            if (Input.GetKeyDown(Tecla.START))
            {
                SceneManager.LoadScene(escena);
            }
        }

        #endregion Public Methods
    }
}