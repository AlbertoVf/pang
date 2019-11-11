using Assets.Scripts;

using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/// <summary>
/// Manager para gestionar el comportamiento de las bolas
/// </summary>
public class BallManager : MonoBehaviour
{
    #region Public Fields

    /// <summary>
    /// The bm.
    /// Variable estatica para acceder a la clase desde otras.
    /// </summary>
    public static BallManager bm;

    /// <summary>
    /// The balls
    /// Lista de bolas que estan en juego
    /// </summary>
    public List<GameObject> balls = new List<GameObject>();

    public AudioClip explosion;
    public GameObject panel;

    /// <summary>
    /// The spliting
    /// Comprueba si esta explotando
    /// </summary>
    public bool spliting;

    #endregion Public Fields

    #region Private Fields

    private AudioSource fuenteAudio;

    /// <summary>
    /// Controla el numero de vidas
    /// </summary>
    private LifeManager lm;

    private PanelPoints panelPoints;
    private Player player;

    #endregion Private Fields

    #region Public Methods

    /// <summary>
    /// Aleatories the number.
    /// Genera una numero aleatorio que se utilizara para obtener items
    /// </summary>
    /// <returns>Aleatorio</returns>
    public int AleatoryNumber()
    {
        return Random.Range(0, 3);
    }

    /// <summary>
    /// Destroys the ball.
    /// Destruye una bola en juego y crea dos bolas de menor tamaño siguiendo la gerarquia
    /// </summary>
    /// <param name="ball">The ball.</param>
    /// <param name="ball1">The ball1.</param>
    /// <param name="ball2">The ball2.</param>
    //sonido 11 al explotar bola
    public void DestroyBall(GameObject ball, GameObject ball1, GameObject ball2)
    {
        balls.Remove(ball);
        Destroy(ball);
        balls.Add(ball1);
        balls.Add(ball2);
    }

    /// <summary>
    /// Dynamites the specified maximum number balls.
    /// Inicia las explosiones de las bolas en juego
    /// </summary>
    /// <param name="maxNumberBalls">The maximum number balls.</param>
    public void Dynamite(int maxNumberBalls)
    {
        StartCoroutine(IEDynamite(maxNumberBalls));
    }

    /// <summary>
    /// Ies the dynamite bh.
    /// Explosion de bolas hasta alcanzar un numero determinado
    /// </summary>
    /// <param name="maxNumberBalls">The maximum number balls.</param>
    /// <returns></returns>
    public IEnumerator IEDynamite(int maxNumberBalls)
    {
        ReloadList();
        spliting = true;
        int numberToFind = 1;
        while (numberToFind < maxNumberBalls)
        {
            foreach (GameObject item in FindBalls(numberToFind))
            {
                item.GetComponent<Ball>().Split();
                Destroy(item);
            }
            yield return new WaitForSeconds(Tiempo.PARPADEO);
            ReloadList();
            numberToFind++;
        }
        spliting = false;
    }

    /// <summary>
    /// Ies the time slow.
    /// Corrutina que ralentiza las bolas
    /// </summary>
    /// <returns></returns>
    public IEnumerator IETimeSlow()
    {
        float time = 0;
        foreach (GameObject item in balls)
        {
            if (item != null)
            {
                item.GetComponent<Ball>().SlowBall();
            }
        }
        while (time < Tiempo.CUENTAATRAS)
        {
            time += Time.deltaTime;
            yield return null;
        }
        foreach (GameObject item in balls)
        {
            if (item != null)
            {
                item.GetComponent<Ball>().NormalSpeedBall();
            }
        }
    }

    /// <summary>
    /// Lasts the ball.
    /// Destruye la bola mas pequeña sin generar ninguna.
    /// </summary>
    /// <param name="ball">The ball.</param>
    public void LastBall(GameObject ball)
    {
        Destroy(ball);
        balls.Remove(ball);
    }

    public void LoseGame()
    {
        foreach (GameObject item in balls)
        {
            item.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            item.GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }

    /// <summary>
    /// Slows the time.
    /// Inicia la ralentizacion del movimiento de las bolas en juego
    /// </summary>
    public void SlowTime()
    {
        StartCoroutine(IETimeSlow());
    }

    public void SonidoExplosion()
    {
        General.Audio(fuenteAudio, explosion);
    }

    /// <summary>
    /// Starts the game.
    /// Inicia el juego impulsando las bolas a derecha o izquierda de manera aleatoria
    /// </summary>
    public void StartGame()
    {
        foreach (GameObject item in balls)
        {
            if (balls.IndexOf(item) % 2 == 0)
            {
                item.GetComponent<Ball>().right = true;
            }
            else
            {
                item.GetComponent<Ball>().right = false;
            }
            item.GetComponent<Ball>().StartForce(item);
        }
    }

    #endregion Public Methods

    #region Private Methods

    private void Awake()
    {
        if (bm == null)
        {
            bm = this;
        }
        else if (bm != this)
        {
            Destroy(gameObject);
        }
        player = FindObjectOfType<Player>();
        lm = FindObjectOfType<LifeManager>();
    }

    /// <summary>
    /// Finds the balls. Comprueba todos los componentes que estan en escena buscando las bolas que tengan el mismo tipo que se pasa por parametro y destrullendolas hasta alcancar el nivel mas pequeño
    /// </summary>
    /// <param name="typeOfBall">The type of ball. Tipo de bola numerado desde el 5 hacia bajo, desde el mayor al menor</param>
    /// <returns>Lista con las bolas que se van a destruir</returns>
    private List<GameObject> FindBalls(int typeOfBall)
    {
        List<GameObject> ballsToDestroy = new List<GameObject>();
        for (int i = 0; i < balls.Count; i++)
        {
            if (balls[i].GetComponent<Ball>().name.Contains(typeOfBall.ToString()) && balls[i] != null)
            {
                ballsToDestroy.Add(balls[i]);
            }
        }
        return ballsToDestroy;
    }

    /// <summary>
    /// Reloads the list. Recarga la lista de bolas en juego
    /// </summary>
    private void ReloadList()
    {
        balls.Clear();
        balls.AddRange(GameObject.FindGameObjectsWithTag("Ball"));
    }

    private void Start()
    {
        balls.AddRange(GameObject.FindGameObjectsWithTag("Ball"));
        fuenteAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (balls.Count == 0)
        {
            player.Win();
            GameManager.inGame = false;
            lm.LifeWin();

            panel.SetActive(true);
            panelPoints = panel.GetComponent<PanelPoints>();
        }
    }

    #endregion Private Methods
}