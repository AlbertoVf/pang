using Assets.Scripts;

using System.Collections;

using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manager para gestionar el inicio de partida en cada nivel
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// The gm
    /// Variable para haceder a la clase desde otras
    /// </summary>
    public static GameManager gm;

    /// <summary>
    /// Comprueba si se ha iniciado el juego
    /// </summary>
    public static bool inGame;

    /// <summary>
    /// Texto de inicio de nivel
    /// </summary>
    public GameObject ready;
   // private Player player;
    public Text timeText;
    float time = General.Tiempos["partida"];

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
}