using Assets.Scripts;
using UnityEngine;

public class FruitItem : MonoBehaviour
{
    bool inGround;
    public Sprite[] fruitSprites;
    SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        sr.sprite = fruitSprites[Random.Range(0, fruitSprites.Length)];
        gameObject.name = sr.sprite.name;
    }

    // Update is called once per frame
    void Update()
    {
        if (!inGround)
        {
            transform.position += Vector3.down * Time.deltaTime * General.velocidades["normal"];
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            inGround = true;
            Destroy(gameObject, General.tiempos["item"]);
        }
        else if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Arrow" || collision.gameObject.tag == "Ancle")
        {
            int score = Random.Range(100, 1000);// metodo de puntuacion temporal
            PopUpManager.pm.InstanciatePopUpText(transform.position, score);
            Destroy(gameObject);
        }
    }
}
