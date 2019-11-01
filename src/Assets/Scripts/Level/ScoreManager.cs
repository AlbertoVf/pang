using Assets.Scripts;

using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    #region Public Fields

    public static ScoreManager sm;
    public int currentScore = General.Interfaz["inicial"];
    public Text scoreText;

    #endregion Public Fields

    #region Public Methods

    public void UpdateScore(int score)
    {
        currentScore += score;
        scoreText.text = currentScore.ToString();
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

    private void Start()
    {
        currentScore = General.Interfaz["inicial"];
        scoreText.text = currentScore.ToString();
        // UpdateScore();
    }

    #endregion Private Methods
}