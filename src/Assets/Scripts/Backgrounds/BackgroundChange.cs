using UnityEngine;
using UnityEngine.UI;

public class BackgroundChange : MonoBehaviour
{
    #region Public Fields

    public Sprite[] backgrounds;

    #endregion Public Fields

    #region Private Fields

    private Image currentBackground;

    #endregion Private Fields

    #region Private Methods

    private void Start()
    {
        currentBackground = GetComponent<Image>();
        currentBackground.sprite = backgrounds[Random.Range(0, backgrounds.Length)];
    }

    #endregion Private Methods
}