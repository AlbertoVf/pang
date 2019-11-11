using Assets.Scripts;

using UnityEngine;

/// <summary>
/// Gestiona los Items que no son frutas. Dinamita, relojes, disparos.
/// </summary>
public class PowerUps : MonoBehaviour
{
    #region Public Fields

    /// <summary>
    /// The power ups animated.
    /// Array con los items que tienen una animacion
    /// </summary>
    public GameObject[] powerUpsAnimated;

    /// <summary>
    /// The power ups static.
    /// Array con los items sin animacion (dinamita, disparos...)
    /// </summary>
    public Sprite[] powerUpsStatic;

    #endregion Public Fields

    #region Private Fields

    /// <summary>
    /// The in ground.
    /// Variable que comprueba si esta en el suelo
    /// </summary>
    private bool inGround;

    /// <summary>
    /// The lm.
    /// Acede a la clase LifeManager
    /// </summary>
    private LifeManager lm;

    /// <summary>
    /// The sr.
    /// Dibuja los items
    /// </summary>
    private SpriteRenderer sr;

    #endregion Private Fields

    #region Private Methods

    /// <summary>
    /// Awakes this instance.
    /// </summary>
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        lm = FindObjectOfType<LifeManager>();
    }

    /// <summary>
    /// Called when [trigger enter2 d].
    /// Establece el comportamiento del item. Si esta en el suelo se destruye en X segundos. Si lo coge el jugador realiza las acciones pertinentes.
    /// </summary>
    /// <param name="collision">The collision.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            inGround = true;

            Destroy(gameObject, Tiempo.ITEMSUELO);//destruir objeto en X segundos
        }
        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.name.Equals("DoubleArrow"))
            {
                ShotManager.shm.ChangeShot(1);//cambio disparo a doble flecha
            }
            else if (gameObject.name.Equals("Ancle"))
            {
                ShotManager.shm.ChangeShot(2);//cambio disparo a ancla
            }
            else if (gameObject.name.Equals("Gun"))
            {
                ShotManager.shm.ChangeShot(3);//cambio disparo a laser
            }
            else if (gameObject.name.Equals("TimeStop"))
            {
                FreezeManager.fm.StartFreeze();
            }
            else if (gameObject.name.Equals("TimeSlow"))
            {
                BallManager.bm.SlowTime();
            }
            else if (gameObject.name.Equals("Life"))
            {
                lm.AmountLifes();
            }
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Starts this instance.
    /// Establece si se genera un powerUp de la lista de estaticos o de la lista de animados
    /// </summary>
    private void Start()
    {
        int r = Random.Range(0, 2);
        if (r == 0)
        {
            sr.sprite = powerUpsStatic[Random.Range(0, powerUpsStatic.Length)];
            gameObject.name = sr.sprite.name;
        }
        else
        {
            Instantiate(powerUpsAnimated[Random.Range(0, powerUpsAnimated.Length)], transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Updates this instance.
    /// Realiza la caida del objeto hasta el suelo
    /// </summary>
    private void Update()
    {
        if (!inGround)
        {
            transform.position += Vector3.down * Time.deltaTime * Velocidad.LENTO;
        }
    }

    #endregion Private Methods
}