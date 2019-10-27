using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager sm;
    public Text scoreText;
    int currentScore =General.Interfaz["inicial"];

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
    void Start()
    {
        currentScore = General.Interfaz["inicial"];
        scoreText.text = currentScore.ToString();
       // UpdateScore();
    }
    public void UpdateScore(int score)
    {
        currentScore += score;
        scoreText.text = currentScore.ToString();
    }
}
