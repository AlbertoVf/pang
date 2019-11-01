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

    #endregion Public Fields

    #region Private Fields

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

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// Called when [trigger enter2 d].
    /// Comprueba si el item colisiona con el suelo o con un elemento que lo destruya y consiga puntos.
    /// </summary>
    /// <param name="collision">The collision.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            inGround = true;
            Destroy(gameObject, General.Tiempos["item"]);
        }
        else if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Arrow" || collision.gameObject.tag == "Ancle")
        {
            int score = General.Interfaz["fruit"];
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

    private void Update()
    {
        if (!inGround)
        {
            transform.position += Vector3.down * Time.deltaTime * General.Velocidades["normal"];
        }
    }

    #endregion Private Methods
}