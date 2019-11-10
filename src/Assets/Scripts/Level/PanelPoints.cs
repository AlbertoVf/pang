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

    private void SetTextBalls()
    {
        ballsDestroyed.text = "X " + balls.ToString();
    }

    private void SetTextFruits()
    {
        totalFruits.text = "X " + fruits.ToString();
    }

    private void SetTextTime()
    {
        totalTime.text = time.ToString() + " s";
    }

    private void SetTotalScore(int score)
    {
        totalScore += score;
        totalScoreCount.text = totalScore.ToString();
    }

    #endregion Private Methods
}