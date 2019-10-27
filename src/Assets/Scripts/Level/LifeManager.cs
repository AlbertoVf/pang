using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    public int lifes = General.Interfaz["vida"];
    public Text lifesText;
    public GameObject lifeDoll;
    Animator animator;

    private void Awake()
    {
        animator = lifeDoll.GetComponent<Animator>();
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
    public void LifeWin()
    {
        animator.SetBool("lose", false);
        animator.SetBool("win", true);
    }
    public void LifeLose()
    {
        animator.SetBool("win", false);
        animator.SetBool("lose", true);

    }
}
