using Assets.Scripts;

using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    #region Public Fields

    public GameObject lifeDoll;
    public int lifes = General.Interfaz["vida"];
    public Text lifesText;

    #endregion Public Fields

    #region Private Fields

    private Animator animator;

    #endregion Private Fields

    #region Public Methods

    public void LifeLose()
    {
        animator.SetBool("win", false);
        animator.SetBool("lose", true);
    }

    public void LifeWin()
    {
        animator.SetBool("lose", false);
        animator.SetBool("win", true);
    }

    public void UpdateLifes(int life)
    {
        if (life > 0)
        {
            lifes += life;
        }
        else
        {
            lifes -= life;
        }
        lifesText.text = "X " + lifes.ToString();
    }

    #endregion Public Methods

    #region Private Methods

    private void Awake()
    {
        animator = lifeDoll.GetComponent<Animator>();
    }

    #endregion Private Methods
}