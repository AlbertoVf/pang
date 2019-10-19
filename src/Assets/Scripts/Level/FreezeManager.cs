using Assets.Scripts;

using System.Collections;

using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manager para gestionar el congelamiento de las bolas
/// </summary>
public class FreezeManager : MonoBehaviour
{
    /// <summary>
    /// The fm
    /// Variable estatica de clase
    /// </summary>
    public static FreezeManager fm;

    /// <summary>
    /// The freeze time text
    /// Texto con el tiempo de congelacion
    /// </summary>
    public Text freezeTimeText;

    /// <summary>
    /// The freeze time count
    /// Cuenta atras para descongelar las bolas
    /// </summary>
    public GameObject freezeTimeCount;

    /// <summary>
    /// The freeze time
    /// Tiempo de congelacion de las bolas
    /// </summary>
    private float freezeTime;

    /// <summary>
    /// The freeze
    /// Comprueba si las bolas estan congeladas
    /// </summary>
    public bool freeze;

    /// <summary>
    /// Awakes this instance.
    /// Asigna la variable estatica de la clase
    /// </summary>
    private void Awake()
    {
        if (fm == null)
        {
            fm = this;
        }
        else if (fm != this)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Starts this instance.
    /// Desactiva el tiempo de congelacion
    /// </summary>
    private void Start()
    {
        freezeTimeCount.SetActive(false);
    }

    /// <summary>
    /// Starts the freeze.
    /// Inicia la corrutina que congela las bolas durante un tiempo determinado
    /// </summary>
    public void StartFreeze()
    {
        freezeTime = General.Tiempos["cuentaAtras"];
        if (!freeze)
        {
            StartCoroutine(IEFreezeTime());
        }
    }

    /// <summary>
    /// Ies the freeze time.
    /// Corrutina para congelar la posicion de las bolas
    /// </summary>
    /// <returns></returns>
    public IEnumerator IEFreezeTime()
    {
        freeze = true;
        foreach (GameObject item in BallManager.bm.balls)
        {
            if (item != null)
            {
                item.GetComponent<Ball>().FreezeBall(item);
            }
        }
        freezeTimeCount.SetActive(true);
        while (freezeTime > 0)
        {
            freezeTime -= Time.deltaTime;
            freezeTimeText.text = freezeTime.ToString("f2");
            yield return null;//espera a cada fotograma
        }
        freezeTimeCount.SetActive(false);
        freezeTime = 0;
        foreach (GameObject item in BallManager.bm.balls)
        {
            if (item != null)
            {
                item.GetComponent<Ball>().UnfreezeBall(item);
            }
        }
        freeze = false;
    }
}