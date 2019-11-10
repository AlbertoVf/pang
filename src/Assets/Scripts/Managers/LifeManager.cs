using Assets.Scripts;

using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    #region Public Fields

    public GameObject lifeDoll;
    public int lifes = Puntuacion.VIDA;
    public Text lifesText;

    #endregion Public Fields

    #region Private Fields

    private Animator animator;

    #endregion Private Fields

    #region Public Methods

    public void AmountLifes()
    {
        lifes++;
        SetLifesText();
    }

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

    public void RestartLifesDoll()
    {
        animator.SetBool("win", false);
        animator.SetBool("lose", false);
    }

    public void SetLifesText()
    {
        lifesText.text = "X " + lifes.ToString();
    }

    public void SubstractLifes()
    {
        lifes--;
        SetLifesText();
    }

    #endregion Public Methods

    #region Private Methods

    private void Awake()
    {
        animator = lifeDoll.GetComponent<Animator>();
    }

    #endregion Private Methods
}