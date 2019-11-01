using Assets.Scripts;

using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelPoints : MonoBehaviour
{
    #region Public Fields

    public Text ballsDestroyed;
    public Text gameScore;
    public Text totalFruits;
    public Text totalScoreCount;
    public Text totalTime;

    #endregion Public Fields

    #region Private Fields

    private int balls;
    private int fruits;
    private int time;
    private int totalScore;

    #endregion Private Fields

    #region Public Methods

    public IEnumerator IETotalScoreAmount()
    {
        float tiempoEspera = General.Tiempos["parpadeo"] / 2;
        while (balls > 0)
        {
            balls--;
            SetTotalScore(General.Interfaz["cuentaBola"]);
            TextBalls();
            ScoreManager.sm.UpdateScore(General.Interfaz["cuentaBola"]);
            yield return new WaitForSeconds(tiempoEspera);
        }
        while (fruits > 0)
        {
            fruits--;
            SetTotalScore(General.Interfaz["cuentaFruit"]);
            TextFruits();
            ScoreManager.sm.UpdateScore(General.Interfaz["cuentaFruit"]);
            yield return new WaitForSeconds(tiempoEspera);
        }
        while (time > 0)
        {
            time--;
            SetTotalScore(General.Interfaz["cuentaTiempo"]);
            TextTime();
            ScoreManager.sm.UpdateScore(General.Interfaz["cuentaTiempo"]);
            yield return new WaitForSeconds(tiempoEspera);
        }

        yield return new WaitForSeconds(tiempoEspera * 2);
        //Carga de nivel
        if (SceneManager.sceneCountInBuildSettings > SceneManager.GetActiveScene().buildIndex + 1)
        {
            GameManager.gm.NextLevel();
        }
    }

    #endregion Public Methods

    #region Private Methods

    private void OnEnable()
    {
        balls = GameManager.gm.ballsDestroyed;
        TextBalls();

        fruits = GameManager.gm.fruitsCatched;
        TextFruits();

        time = (int)GameManager.gm.time + 1;
        TextTime();

        SetTotalScore(ScoreManager.sm.currentScore);
        StartCoroutine(IETotalScoreAmount());
    }

    private void SetTotalScore(int score)
    {
        totalScore += score;
        totalScoreCount.text = totalScore.ToString();
    }

    private void TextBalls()
    {
        ballsDestroyed.text = "X " + balls.ToString();
    }

    private void TextFruits()
    {
        totalFruits.text = "X " + fruits.ToString();
    }

    private void TextTime()
    {
        totalTime.text = time.ToString() + " s";
    }

    #endregion Private Methods
}