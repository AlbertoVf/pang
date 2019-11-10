using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    /// <summary>
    /// The escala gravedad. Escala de gravedad de los objetos. La gravedad por defecto es de (-9.81f)
    /// </summary>
    public class Gravedad
    {
        #region Public Fields

        public const float ALTA = 2f;
        public const float BAJA = 0.5f;
        public const float NORMAL = 1F;

        #endregion Public Fields
    }

    public class Limite
    {
        #region Public Fields

        public const float DERECHA = 8.24f;
        public const float INFERIOR = -2.57f;
        public const float IZQUIERDA = -8.24f;
        public const float SUPERIOR = 4.13f;

        #endregion Public Fields
    }

    /// <summary>
    /// Puntuacion durante las partidas.
    /// </summary>
    public class Puntuacion
    {
        #region Public Fields

        public const int ACTUAL = 0;
        public const int BOLA = 512;
        public const int FRUIT = 1024;
        public const int INICIAL = 0;
        public const int ITEM = 128;
        public const int RECORD = 0;
        public const int VIDA = 3;

        #endregion Public Fields
    }

    /// <summary>
    /// Puntuacion durante el recuento de puntos. Son puntos extra
    /// </summary>
    public class PuntuacionRecuento
    {
        #region Public Fields

        public const int BOLA = 32;
        public const int FRUIT = 64;
        public const int TIEMPO = 16;

        #endregion Public Fields
    }

    /// <summary>
    /// Gestiona las teclas que se utilizaran en el juego.
    /// </summary>
    public class Tecla
    {
        #region Public Fields

        public const KeyCode DERECHA = KeyCode.RightArrow;
        public const KeyCode DISPARAR = KeyCode.Space;
        public const KeyCode IZQUIERDA = KeyCode.LeftArrow;
        public const KeyCode PAUSA = KeyCode.Return;
        public const KeyCode START = KeyCode.Return;

        #endregion Public Fields
    }

    /// <summary>
    /// Tiempos de duracion en segundos.
    /// </summary>
    public class Tiempo
    {
        #region Public Fields

        public const float CONGELACION = 6f;
        public const float CUENTAATRAS = 3f;
        public const float ITEMSUELO = 3f;
        public const float PARPADEO = 0.3f;
        public const float PARTIDA = 100f;
        public const float TEXTO = 1f;

        #endregion Public Fields
    }

    /// <summary>
    /// Tiempos de espera en segundos
    /// </summary>
    public class TiempoEspera
    {
        #region Public Fields

        public const float ANCLA = 0.5f;
        public const float LARGA = 1f;
        public const float NORMAL = 0.5f;
        public const float RAPIDA = 0.15f;

        #endregion Public Fields
    }

    /// <summary>
    /// Velocidades de los proyectiles y el jugador.
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
        #region Public Fields

        public static General g;

        #endregion Public Fields

        #region Public Methods

        /// <summary>
        /// Carga una escena al presionar la tecla enter.
        /// </summary>
        /// <param name="escena">Nombre de la escena</param>
        public void CargarEscena(string escena)
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
        public void CargarEscena(int escena)
        {
            if (Input.GetKeyDown(Tecla.START))
            {
                SceneManager.LoadScene(escena);
            }
        }

        #endregion Public Methods
    }
}