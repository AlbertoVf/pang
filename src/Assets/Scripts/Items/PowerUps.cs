using Assets.Scripts;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public Sprite[] powerUpsStatic;
    public GameObject[] powerUpsAnimated;
    bool inGround;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
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

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

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
            
            Destroy(gameObject,5);//destruir objeto en X segundos
        }
        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.name.Equals("DoubleArrow"))
            {
                //cambio disparo a doble flecha
                ShotManager.shm.ChangeShot(1);
            }
            else if (gameObject.name.Equals("Ancle"))
            {
                //cambio disparo a ancla
                ShotManager.shm.ChangeShot(2);
            }
            else if (gameObject.name.Equals("Gun"))
            {
                //cambio disparo a laser
                ShotManager.shm.ChangeShot(3);
            }
            else if (gameObject.name.Equals("TimeStop"))
            {
                FreezeManager.fm.StartFreeze();
            }
            Destroy(gameObject);
        }

    }
}
