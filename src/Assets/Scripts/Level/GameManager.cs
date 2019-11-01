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

    /// <summary>
    /// Texto de inicio de nivel
    /// </summary>
    public GameObject ready;

    public float time = General.Tiempos["partida"];
    public Text timeText;

    #endregion Public Fields

    #region Private Fields

    private Fruits fruits;

    #endregion Private Fields

    #region Public Methods

    /// <summary>
    /// Ies the game start.
    /// Inicia el nivel
    /// </summary>
    /// <returns></returns>
    public IEnumerator IEGameStart()
    {
        yield return new WaitForSeconds(General.Tiempos["cuentaAtras"]);
        ready.SetActive(false);
        BallManager.bm.StartGame();
        inGame = true;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
    }

    private void Start()
    {
        timeText.text = " TIME " + time.ToString("f0");
        StartCoroutine(IEGameStart());
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