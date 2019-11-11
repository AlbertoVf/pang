using Assets.Scripts;

using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Gestiona el panel de puntos cuando gana el nivel
/// </summary>
public class PanelPoints : MonoBehaviour
{
    #region Public Fields

    /// <summary>
    /// The balls destroyed
    /// </summary>
    public Text ballsDestroyed;

    /// <summary>
    /// The game score
    /// </summary>
    public Text gameScore;

    /// <summary>
    /// The total fruits
    /// </summary>
    public Text totalFruits;

    /// <summary>
    /// The total score count
    /// </summary>
    public Text totalScoreCount;

    /// <summary>
    /// The total time
    /// </summary>
    public Text totalTime;

    #endregion Public Fields

    #region Private Fields

    /// <summary>
    /// The balls
    /// </summary>
    private int balls;

    /// <summary>
    /// The fruits
    /// </summary>
    private int fruits;

    /// <summary>
    /// The time
    /// </summary>
    private int time;

    /// <summary>
    /// The total score
    /// </summary>
    private int totalScore;

    #endregion Private Fields

    #region Public Methods

    /// <summary>
    /// Ies the total score amount.
    /// Gestiona el recuento de puntos
    /// </summary>
    /// <returns></returns>
    public IEnumerator IETotalScoreAmount()
    {
        float tiempoEspera = TiempoEspera.RAPIDA;
        while (balls > 0)
        {
            balls--;
            SetTotalScore(PuntuacionRecuento.BOLA);
            SetTextBalls();
            ScoreManager.sm.UpdateScore(PuntuacionRecuento.BOLA);
            yield return new WaitForSeconds(tiempoEspera);
        }
        while (fruits > 0)
        {
            fruits--;
            SetTotalScore(PuntuacionRecuento.FRUIT);
            SetTextFruits();
            ScoreManager.sm.UpdateScore(PuntuacionRecuento.FRUIT);
            yield return new WaitForSeconds(tiempoEspera);
        }
        while (time > 0)
        {
            time--;
            SetTotalScore(PuntuacionRecuento.TIEMPO);
            SetTextTime();
            ScoreManager.sm.UpdateScore(PuntuacionRecuento.TIEMPO);
            yield return new WaitForSeconds(tiempoEspera);
        }

        yield return new WaitForSeconds(tiempoEspera * 2);
        if (SceneManager.sceneCountInBuildSettings > SceneManager.GetActiveScene().buildIndex + 1)
        {
            GameManager.gm.NextLevel();
        }
    }

    #endregion Public Methods

    #region Private Methods

    /// <summary>
    /// Called when [enable].
    /// Actualiza el texto de la puntuacion
    /// </summary>
    private void OnEnable()
    {
        balls = GameManager.gm.ballsDestroyed;
        SetTextBalls();

        fruits = GameManager.gm.fruitsCatched;
        SetTextFruits();

        time = (int)GameManager.gm.time + 1;
        SetTextTime();

        SetTotalScore(ScoreManager.sm.currentScore);
        StartCoroutine(IETotalScoreAmount());
    }

    /// <summary>
    /// Sets the text balls.
    /// </summary>
    private void SetTextBalls()
    {
        ballsDestroyed.text = "X " + balls.ToString();
    }

    /// <summary>
    /// Sets the text fruits.
    /// </summary>
    private void SetTextFruits()
    {
        totalFruits.text = "X " + fruits.ToString();
    }

    /// <summary>
    /// Sets the text time.
    /// </summary>
    private void SetTextTime()
    {
        totalTime.text = time.ToString() + " s";
    }

    /// <summary>
    /// Sets the total score.
    /// </summary>
    /// <param name="score">The score.</param>
    private void SetTotalScore(int score)
    {
        totalScore += score;
        totalScoreCount.text = totalScore.ToString();
    }

    #endregion Private Methods
}