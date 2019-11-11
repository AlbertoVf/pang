using Assets.Scripts;

using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Manager para gestionar el inicio de partida en cada nivel
/// </summary>
public class GameManager : MonoBehaviour
{
    #region Public Fields

    /// <summary>
    /// The gm
    /// Variable para haceder a la clase desde otras
    /// </summary>
    public static GameManager gm;

    /// <summary>
    /// Comprueba si se ha iniciado el juego
    /// </summary>
    public static bool inGame;

    public int ballsDestroyed = 0;
    public int fruitsCatched = 0;

    public GameObject gameOver;

    /// <summary>
    /// Texto de inicio de nivel
    /// </summary>
    public GameObject ready;

    public float time = Tiempo.PARTIDA;
    public Text timeText;

    #endregion Public Fields

    #region Private Fields

    private Fruits fruits;
    private LifeManager lm;

    #endregion Private Fields

    #region Public Methods

    public IEnumerator IEGameOver()
    {
        gameOver.SetActive(true);
        yield return new WaitForSeconds(Tiempo.CUENTAATRAS);
        General.CargarEscena(0);
    }

    /// <summary>
    /// Ies the game start.
    /// Inicia el nivel
    /// </summary>
    /// <returns></returns>
    public IEnumerator IEGameStart()
    {
        yield return new WaitForSeconds(Tiempo.CUENTAATRAS);
        ready.SetActive(false);
        BallManager.bm.StartGame();
        inGame = true;
    }

    public void NextLevel()
    {
        lm.RestartLifesDoll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void StartGameOver()
    {
        StartCoroutine(IEGameOver());
    }

    public void UpdateBallDestroyed()
    {
        ballsDestroyed++;
        if (ballsDestroyed % Random.Range(3, 13) == 0 && BallManager.bm.balls.Count > 0)
        {
            fruits.InstaciateFruit();
        }
    }

    #endregion Public Methods

    #region Private Methods

    /// <summary>
    /// Awakes this instance.
    /// Establece la variable estatica de clase
    /// </summary>
    private void Awake()
    {
        if (gm == null)
        {
            gm = this;
        }
        else if (gm != null)
        {
            Destroy(gameObject);
        }
        fruits = FindObjectOfType<Fruits>();
        lm = FindObjectOfType<LifeManager>();
    }

    private void Start()
    {
        timeText.text = " TIME " + time.ToString("f0");
        StartCoroutine(IEGameStart());
        gameOver.SetActive(false);
        ScoreManager.sm.UpdateHightScore();
    }

    private void Update()
    {
        if (inGame)
        {
            time -= Time.deltaTime;
            timeText.text = " TIME " + time.ToString("f0");
        }
    }

    #endregion Private Methods
}