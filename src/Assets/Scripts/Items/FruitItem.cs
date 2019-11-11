using Assets.Scripts;

using UnityEngine;

/// <summary>
/// Gestiona las listas de items de premios
/// </summary>
public class FruitItem : MonoBehaviour
{
    #region Public Fields

    /// <summary>
    /// The fruit sprites.
    /// Array con todas las frutas
    /// </summary>
    public Sprite[] fruitSprites;

    /// <summary>
    /// The item sonido
    /// Audio que se reproducira al coger el objeto
    /// </summary>
    public AudioClip itemSonido;

    #endregion Public Fields

    #region Private Fields

    /// <summary>
    /// The fuente audio
    /// </summary>
    private AudioSource fuenteAudio;

    /// <summary>
    /// The in ground.
    /// Variable que indica si esta en el suelo
    /// </summary>
    private bool inGround;

    /// <summary>
    /// The sr.
    /// Sprite renderer para dibujar la fruta
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
        fuenteAudio = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Called when [trigger enter2 d].
    /// Comprueba si el item colisiona con el suelo o con un elemento que lo destruya y consiga puntos.
    /// </summary>
    /// <param name="collision">The collision.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        General.Audio(fuenteAudio, itemSonido);
        if (collision.gameObject.tag == "Ground")
        {
            inGround = true;
            Destroy(gameObject, Tiempo.ITEMSUELO);
        }
        else if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Arrow" || collision.gameObject.tag == "Ancle")
        {
            int score = Puntuacion.FRUIT;
            ScoreManager.sm.UpdateScore(score);

            PopUpManager.pm.InstanciatePopUpText(transform.position, score);
            GameManager.gm.fruitsCatched++;
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Starts this instance.
    /// Genera un item aleatorio
    /// </summary>
    private void Start()
    {
        sr.sprite = fruitSprites[Random.Range(0, fruitSprites.Length)];
        gameObject.name = sr.sprite.name;
    }

    /// <summary>
    /// Updates this instance.
    /// Realiza la caida del objeto hasta el suelo
    /// </summary>
    private void Update()
    {
        if (!inGround)
        {
            transform.position += Vector3.down * Time.deltaTime * Velocidad.NORMAL;
        }
    }

    #endregion Private Methods
}