using Assets.Scripts;

using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    #region Public Fields

    /// <summary>
    /// The sm
    /// </summary>
    public static ScoreManager sm;

    /// <summary>
    /// The current score
    /// </summary>
    public int currentScore = Puntuacion.INICIAL;

    /// <summary>
    /// The hight score
    /// </summary>
    public int hightScore = 0;

    /// <summary>
    /// The hight score text
    /// </summary>
    public Text hightScoreText;

    /// <summary>
    /// The score text
    /// </summary>
    public Text scoreText;

    #endregion Public Fields

    #region Public Methods

    /// <summary>
    /// Updates the hight score.
    /// </summary>
    public void UpdateHightScore()
    {
        hightScore = PlayerPrefs.GetInt("HightScore");
        SetTextHightScore();
    }

    /// <summary>
    /// Updates the score.
    /// </summary>
    /// <param name="score">The score.</param>
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

    /// <summary>
    /// Awakes this instance.
    /// </summary>
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

    /// <summary>
    /// Sets the text hight score.
    /// </summary>
    private void SetTextHightScore()
    {
        hightScoreText.text = "HI: " + hightScore.ToString();
    }

    /// <summary>
    /// Starts this instance.
    /// </summary>
    private void Start()
    {
        currentScore = Puntuacion.INICIAL;
        scoreText.text = currentScore.ToString();
    }

    #endregion Private Methods
}