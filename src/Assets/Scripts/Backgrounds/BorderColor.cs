using Assets.Scripts;

using System.Collections;

using UnityEngine;
using UnityEngine.UI;

public class BorderColor : MonoBehaviour
{
    #region Private Fields

    private Image borderColor;
    private bool danger;
    private Color dangerColor = new Color((231f / 255), (60f / 255), (42f / 255));//rojo
    private Color normalColor;
    private float time;

    #endregion Private Fields

    #region Private Methods

    private void Awake()
    {
        borderColor = GetComponent<Image>();
    }

    private IEnumerator IEDanger()
    {
        danger = true;
        while (time > 0)
        {
            if (borderColor.color == normalColor)
            {
                borderColor.color = dangerColor;
            }
            else
            {
                borderColor.color = normalColor;
            }
            yield return new WaitForSeconds(General.Tiempos["parpadeo"] * 1.5f);
        }
    }

    private void Start()
    {
        normalColor = borderColor.color;
    }

    private void Update()
    {
        time = GameManager.gm.time;
        if (time <= 10 && !danger)
        {
            StartCoroutine(IEDanger());
        }
    }

    #endregion Private Methods
}