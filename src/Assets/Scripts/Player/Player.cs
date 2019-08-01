using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 4f;
    float movement = 0;
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
        rb.MovePosition(rb.position + Vector2.right * movement * Time.fixedDeltaTime);
    }
}
