using UnityEngine;
using Assets.Scripts;
public class ShotManager : MonoBehaviour
{
    public static ShotManager shm;
    public GameObject[] Shots;
    Transform player;
    private int maxShots;
    private int numberOfShots = 0;
    public int typeOfShot;//0: arrow, 1: double arrow, 2: ancle, 3: laser
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        typeOfShot = 0;
        maxShots = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (CanShot() && Input.GetKeyDown(General.teclas["disparar"]))
        {
            Shot();
        }
    }
    void Awake()
    {
        if (shm == null)
        {
            shm = this;
        }
        else if (shm != this)
        {
            Destroy(gameObject);
        }
        player = FindObjectOfType<Player>().transform;
    }

    /// <summary>
    /// Comprueba si el jugador puede disparar
    /// </summary>
    /// <returns>true si puede disparar</returns>
    bool CanShot()
    {
        if (numberOfShots < maxShots)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Realiza el disparo
    /// </summary>
    void Shot()
    {
        if (typeOfShot != 3)
        {
            Instantiate(Shots[typeOfShot], player.position - new Vector3(0, 0.15f, 0), Quaternion.identity);
        }
        else
        {
            Instantiate(Shots[3], new Vector2(player.position.x + .5f, player.position.y + 1.15f), Quaternion.Euler(new Vector3(0, 0, -5)));
            Instantiate(Shots[3], new Vector2(player.position.x, player.position.y + 1.15f), Quaternion.identity);
            Instantiate(Shots[3], new Vector2(player.position.x - .5f, player.position.y + 1.15f), Quaternion.Euler(new Vector3(0, 0, 5)));
        }
        numberOfShots++;
    }

    /// <summary>
    /// Destruye el proyectil
    /// </summary>
    public void DestroyShot()
    {
        if (numberOfShots > 0 && numberOfShots <= maxShots)
        {
            numberOfShots--;
        }
    }
}
