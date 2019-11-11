using Assets.Scripts;

using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Gestiona el muñeco de vidas de la interfaz
/// </summary>
public class LifeManager : MonoBehaviour
{
    #region Public Fields

    /// <summary>
    /// The life doll
    /// </summary>
    public GameObject lifeDoll;

    /// <summary>
    /// The lifes
    /// </summary>
    public int lifes = Puntuacion.VIDA;

    /// <summary>
    /// The lifes text
    /// </summary>
    public Text lifesText;

    #endregion Public Fields

    #region Private Fields

    /// <summary>
    /// The animator
    /// </summary>
    private Animator animator;

    #endregion Private Fields

    #region Public Methods

    /// <summary>
    /// Amounts the lifes.
    /// </summary>
    public void AmountLifes()
    {
        lifes++;
        SetLifesText();
    }

    /// <summary>
    /// Lifes the lose.
    /// </summary>
    public void LifeLose()
    {
        animator.SetBool("win", false);
        animator.SetBool("lose", true);
    }

    /// <summary>
    /// Lifes the win.
    /// </summary>
    public void LifeWin()
    {
        animator.SetBool("lose", false);
        animator.SetBool("win", true);
    }

    /// <summary>
    /// Restarts the lifes doll.
    /// </summary>
    public void RestartLifesDoll()
    {
        animator.SetBool("win", false);
        animator.SetBool("lose", false);
    }

    /// <summary>
    /// Sets the lifes text.
    /// </summary>
    public void SetLifesText()
    {
        lifesText.text = "X " + lifes.ToString();
    }

    /// <summary>
    /// Substracts the lifes.
    /// </summary>
    public void SubstractLifes()
    {
        lifes--;
        SetLifesText();
    }

    #endregion Public Methods

    #region Private Methods

    /// <summary>
    /// Awakes this instance.
    /// </summary>
    private void Awake()
    {
        animator = lifeDoll.GetComponent<Animator>();
    }

    #endregion Private Methods
}