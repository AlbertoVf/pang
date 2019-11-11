using UnityEngine;

/// <summary>
/// Manager para gestionar los items que generan puntuacion
/// </summary>
public class PopUpManager : MonoBehaviour
{
    #region Public Fields

    /// <summary>
    /// The pm
    /// Variable estatica para haceder a la clase desde otras
    /// </summary>
    public static PopUpManager pm;

    /// <summary>
    /// The pop up text
    /// Texto con la puntuacion del item
    /// </summary>
    public GameObject popUpText;

    #endregion Public Fields

    #region Public Methods

    /// <summary>
    /// Instanciates the pop up text.
    /// Crea el texto con la puntuacion al explotar o coger un item
    /// </summary>
    /// <param name="starPos">The star position.</param>
    /// <param name="textScore">The text score.</param>
    public void InstanciatePopUpText(Vector2 starPos, int textScore)
    {
        GameObject pop = Instantiate(popUpText);
        pop.transform.position = starPos;
        pop.GetComponent<TextMesh>().text = textScore.ToString();
    }

    #endregion Public Methods

    #region Private Methods

    /// <summary>
    /// Awakes this instance.
    /// Asigna la variable estatica
    /// </summary>
    private void Awake()
    {
        if (pm == null)
        {
            pm = this;
        }
        else if (pm != null)
        {
            Destroy(gameObject);
        }
    }

    #endregion Private Methods
}