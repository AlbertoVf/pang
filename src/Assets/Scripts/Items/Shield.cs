using Assets.Scripts; 
using UnityEngine;

public class Shield : MonoBehaviour
{
    private bool inGround;

    // Update is called once per frame
    void Update()
    {
        if (!inGround)
        {
            transform.position += Vector3.down * Time.deltaTime * General.velocidades["lento"];
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            inGround = true;
            Destroy(gameObject, General.tiempo["item"]);
        }
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().shield.SetActive(true);
            collision.gameObject.GetComponent<Player>().blink = false;
            Destroy(gameObject);
        }
    }
}
