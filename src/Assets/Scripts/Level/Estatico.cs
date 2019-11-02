using UnityEngine;

public class Estatico : MonoBehaviour
{
    #region Public Fields

    public static Estatico e;

    #endregion Public Fields

    #region Private Methods

    private void Awake()
    {
        if (e == null)
        {
            e = this;
        }
        else if (e != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    #endregion Private Methods
}