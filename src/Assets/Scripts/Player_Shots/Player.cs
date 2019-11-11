using Assets.Scripts;

using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Gestiona el jugador
/// </summary>
public class Player : MonoBehaviour
{
    #region Public Fields

    /// <summary>
    /// The blink
    /// Comprueba si parpadea, ha perdido el escudo
    /// </summary>
    public bool blink;

    public AudioClip escudoSonido;

    /// <summary>
    /// The shield
    /// Comprueba si esta activado el escudo
    /// </summary>
    public GameObject shield;

    #endregion Public Fields

    #region Private Fields

    /// <summary>
    /// The animator
    /// </summary>
    private Animator animator;

    private AudioSource fuenteAudio;

    /// <summary>
    /// The left wall
    /// Comprueba si colisiona con el muro derecho
    /// </summary>
    private bool leftWall;

    /// <summary>
    /// Controla el numero de vidas
    /// </summary>
    private LifeManager lm;

    /// <summary>
    /// The movement
    /// </summary>
    private float movement = Velocidad.NULO;

    /// <summary>
    /// The rb
    /// </summary>
    private Rigidbody2D rb;

    /// <summary>
    /// The right wall
    /// Comprueba si colisiona con el muro izquierdo
    /// </summary>
    private bool rightWall;

    /// <summary>
    /// The speed
    /// </summary>
    private float speed = Velocidad.NORMAL;

    /// <summary>
    /// The sr
    /// </summary>
    private SpriteRenderer sr;

    #endregion Private Fields

    #region Public Methods

    /// <summary>
    /// Wins this instance.
    /// Cambia a animacion de ganar y desactiva el escudo
    /// </summary>
    public void Win()
    {
        shield.SetActive(false);
        animator.SetBool("win", true);
    }

    #endregion Public Methods

    #region Private Methods

    /// <summary>
    /// Awakes this instance.
    /// Asigna las variables
    /// </summary>
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        lm = FindObjectOfType<LifeManager>();
    }

    /// <summary>
    /// Fixeds the update.
    /// Gestiona la posibilidad de movimiento
    /// </summary>
    private void FixedUpdate()
    {
        if (GameManager.inGame)
        {
            if (leftWall)
            {
                if (Input.GetKey(Tecla.IZQUIERDA))
                {
                    speed = Velocidad.NULO;
                }
                else if (Input.GetKey(Tecla.DERECHA) || Input.GetKeyUp(Tecla.IZQUIERDA))
                {
                    speed = Velocidad.NORMAL;
                }
            }
            if (rightWall)
            {
                if (Input.GetKey(Tecla.IZQUIERDA) || Input.GetKeyUp(Tecla.DERECHA))
                {
                    speed = Velocidad.NORMAL;
                }
                else if (Input.GetKey(Tecla.DERECHA))
                {
                    speed = Velocidad.NULO;
                }
            }
            rb.MovePosition(rb.position + Vector2.right * movement * Time.fixedDeltaTime);
        }
    }

    /// <summary>
    /// Ies the blinking.
    /// Corrutina de parpadeo
    /// </summary>
    /// <returns></returns>
    private IEnumerator IEBlinking()
    {
        blink = true;
        for (int i = 0; i < Tiempo.CUENTAATRAS; i++)
        {
            if (blink && GameManager.inGame)
            {
                sr.color = new Color(1, 1, 1, 0);
                yield return new WaitForSeconds(Tiempo.PARPADEO);
                sr.color = new Color(1, 1, 1, 1);
                yield return new WaitForSeconds(Tiempo.PARPADEO);
            }
            else
            {
                break;
            }
        }
        blink = false;
    }

    /// <summary>
    /// Ies the lose.
    /// Corrutina la perdida de partida. Cambio de animacion y fuerza para sacar al personaje de la pantalla
    /// </summary>
    /// <returns></returns>
    private IEnumerator IELose()
    {
        GameManager.inGame = false;
        lm.LifeLose();

        animator.SetBool("lose", true);
        BallManager.bm.LoseGame();

        yield return new WaitForSeconds(Tiempo.TEXTO);
        rb.isKinematic = false;

        if (transform.position.x < 0)
        {
            rb.AddForce(new Vector2(-10, 10), ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(new Vector2(10, 10), ForceMode2D.Impulse);
        }
    }

    private void OnBecameInvisible()
    {
        if (lm.lifes <= 0)
        {
            General.CargarEscena(0); ;// AJUSTAR PARA QUE EL DISEÑO DE LAS VIDAS QUEDE EN 0
            GameManager.gm.StartGameOver();
        }
        else
        {
            Invoke("ReloadLevel", Tiempo.CUENTAATRAS);
        }
    }

    /// <summary>
    /// Called when [trigger enter2 d].
    /// Gestiona la perdida de escudo al chocar con una bola y al perder la partida
    /// </summary>
    /// <param name="collision">The collision.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.inGame && !FreezeManager.fm.freeze)
        {
            if (collision.gameObject.tag == "Ball")
            {
                if (shield.activeInHierarchy)
                {
                    shield.SetActive(false);
                    //sonido
                    General.Audio(fuenteAudio, escudoSonido);
                    StartCoroutine(IEBlinking());
                }
                else
                {
                    if (!blink)
                    {
                        General.Audio(fuenteAudio, escudoSonido);
                        StartCoroutine(IELose());
                    }
                }
            }
            if (!GameManager.inGame && (collision.gameObject.tag == "Right" || collision.gameObject.tag == "Left"))
            {
                sr.flipX = !sr.flipX;
                rb.velocity /= 3;
                rb.velocity *= -1;
                rb.AddForce(Vector3.up * 5, ForceMode2D.Impulse);
            }
        }
    }

    /// <summary>
    /// Comprueba si el jugador ya ha salido de un objeto con el que colisionaba
    /// </summary>
    /// <param name="collision">Objeto con el que estaba colisionando</param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Left")
        {
            leftWall = false;
        }
        else if (collision.gameObject.tag == "Right")
        {
            rightWall = false;
        }
    }

    /// <summary>
    /// Comprueba si el jugador esta en contacto con una colision
    /// </summary>
    /// <param name="collision">Objeto con el que esta colisionando</param>
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Left")
        {
            leftWall = true;
        }
        else if (collision.gameObject.tag == "Right")
        {
            rightWall = true;
        }
    }

    /// <summary>
    /// Reloads the level.
    /// Recarga la escena y reestablece el muñeco de las vidas.
    /// Es una invocacion, no una llamada.
    /// </summary>
    private void ReloadLevel()
    {
        lm.SubstractLifes();
        lm.RestartLifesDoll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Start()
    {
        fuenteAudio = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Updates this instance.
    /// Cambia la direccion del sprite del jugador
    /// </summary>
    private void Update()
    {
        if (GameManager.inGame)
        {
            movement = Input.GetAxisRaw("Horizontal") * speed;
            animator.SetInteger("velX", Mathf.RoundToInt(movement));
            if (movement < Velocidad.NULO)
            {
                sr.flipX = true;
            }
            else
            {
                sr.flipX = false;
            }
        }
    }

    #endregion Private Methods
}