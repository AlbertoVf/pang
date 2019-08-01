using Assets.Scripts;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 4f;
    float movement = 0;
   // float newX;
    bool rightWall;
    bool leftWall;
    private Rigidbody2D rb;
    private Animator animator;
    SpriteRenderer sr;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxisRaw("Horizontal") * speed;
        animator.SetInteger("velX", Mathf.RoundToInt(movement));
        if (movement < 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }

    private void FixedUpdate()
    {
        if (leftWall)
        {
            if (Input.GetKey(General.teclas["izquierda"]))
            {
                speed = 0;
            }
            else if (Input.GetKey(General.teclas["derecha"]) || Input.GetKeyUp(General.teclas["izquierda"]))
            {
                speed = 4;
            }
        }
        if (rightWall)
        {
            if (Input.GetKey(General.teclas["izquierda"]) || Input.GetKeyUp(General.teclas["derecha"]))
            {
                speed = 4;
            }
            else if (Input.GetKey(General.teclas["derecha"]))
            {
                speed = 0;
            }
        }
        rb.MovePosition(rb.position + Vector2.right * movement * Time.fixedDeltaTime);
        //newX = Mathf.Clamp(transform.position.x, General.limites["izquierda"], General.limites["derecha"]);
        //transform.position = new Vector2(newX, transform.position.y);
    }


    /// <summary>
    /// Comprueba si el jugador esta en contacto con una colision
    /// </summary>
    /// <param name="collision">Objeto con el que esta colisionando</param>
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Left")
        {
            leftWall = true;
        }else if (collision.gameObject.tag == "Right")
        {
            rightWall = true;
        }
    }
    /// <summary>
    /// Comprueba si el jugador ya ha salido de un objeto con el que colisionaba
    /// </summary>
    /// <param name="collision">Objeto con el que estaba colisionando</param>
    private void OnCollisionExit2D(Collision2D collision)
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
}
