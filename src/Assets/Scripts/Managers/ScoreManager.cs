using Assets.Scripts;

using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    #region Public Fields

    public static ScoreManager sm;
    public int currentScore = General.Interfaz["inicial"];
    public int hightScore = 0;
    public Text hightScoreText;
    public Text scoreText;

    #endregion Public Fields

    #region Public Methods

    public void UpdateHightScore()
    {
        hightScore = PlayerPrefs.GetInt("HightScore");
        SetTextHightScore();
    }

    public void UpdateScore(int score)
    {
        currentScore += score;
        scoreText.text = currentScore.ToString();

        if (currentScore > hightScore)
        {
            hightScore = currentScore;
            SetTextHightScore();
            PlayerPrefs.SetInt("HightScore", hightScore);
        }
    }

    #endregion Public Methods

    #region Private Methods

    private void Awake()
    {
        if (sm == null)
        {
            sm = this;
        }
        else if (sm != this)
        {
            Destroy(gameObject);
        }
    }

    private void SetTextHightScore()
    {
        hightScoreText.text = "HI: " + hightScore.ToString();
    }

    private void Start()
    {
        currentScore = General.Interfaz["inicial"];
        scoreText.text = currentScore.ToString();
    }

    #endregion Private Methods
}