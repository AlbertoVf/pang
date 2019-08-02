using UnityEngine;
using Assets.Scripts;
public class ShotManager : MonoBehaviour
{
    public static ShotManager shm;
    public GameObject[] Shots;
    Transform player;
    private int maxShots;
    private int numberOfShots = 0;
    private int typeOfShot;//0: arrow, 1: double arrow, 2: ancle, 3: laser
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
    private void Awake()
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
    private bool CanShot()
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
    private void Shot()
    {
        Instantiate(Shots[typeOfShot], player.position - new Vector3(0, 0.15f, 0), Quaternion.identity);
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
