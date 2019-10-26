using Assets.Scripts;

using UnityEngine;

/// <summary>
/// Manager para gestionar los disparos.
/// </summary>
public class ShotManager : MonoBehaviour
{
    /// <summary>
    /// The SHM.
    /// Variable estatica para acceder a la clase desde otras
    /// </summary>
    public static ShotManager shm;

    /// <summary>
    /// The shots
    /// Array con los tipos de disparos
    /// </summary>
    public GameObject[] Shots;

    /// <summary>
    /// The player
    /// </summary>
    private Transform player;

    /// <summary>
    /// The maximum shots
    /// </summary>
    private int maxShots;

    /// <summary>
    /// The number of shots
    /// </summary>
    private int numberOfShots = 0;

    /// <summary>
    /// The type of shot.
    /// </summary>
    public int typeOfShot;

    /// <summary>
    /// The animator
    /// </summary>
    private Animator animator;

    CurrentShotImage shotImage;
    /// <summary>
    /// Awakes this instance.
    /// Asigna la variable estatica y el jugador
    /// </summary>
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
        shotImage = FindObjectOfType<CurrentShotImage>();
    }

    /// <summary>
    /// Starts this instance.
    /// Establece el tipo de disparo y el numero de disparos disponibles
    /// </summary>
    private void Start()
    {
        typeOfShot = 0;
        maxShots = 1;
    }

    /// <summary>
    /// Updates this instance.
    /// Realiza un disparo y reestablece el numero de disparos
    /// </summary>
    private void Update()
    {
        if (CanShot() && Input.GetKeyDown(General.Teclas["disparar"]))
        {
            Shot();
        }
        if (numberOfShots == maxShots && GameObject.FindGameObjectsWithTag("Arrow").Length == 0 && GameObject.FindGameObjectsWithTag("Ancle").Length == 0)
        {
            numberOfShots = 0;
        }
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
    /// Changes the shot. Intercambia el tipo de desparo
    /// </summary>
    /// <param name="type">The type. 0: arrow, 1: double arrow, 2: ancle, 3: laser</param>
    public void ChangeShot(int type)
    {
        if (typeOfShot != type)
        {
            switch (type)
            {
                case 0:
                    maxShots = 1;
                    shotImage.CurrentShot("");
                    break;
                case 1:
                    shotImage.CurrentShot("Arrow");
                    maxShots = 2;
                    break;
                case 2:
                    shotImage.CurrentShot("Ancle");
                    maxShots = 1;
                    break;
                case 3:
                    shotImage.CurrentShot("Gun");
                    maxShots = 3;
                    break;
            }
            typeOfShot = type;
            numberOfShots = 0;

            int score = General.Puntuaciones["item"];
            ScoreManager.sm.UpdateScore(score);
            PopUpManager.pm.InstanciatePopUpText(transform.position, score);
        }
    }

    /// <summary>
    /// Destruye el proyectil
    /// </summary>
    public void DestroyShot()
    {
        if (numberOfShots > 0 && numberOfShots < maxShots)
        {
            numberOfShots--;
        }
    }

    /// <summary>
    /// Shots this instance.
    /// Instancia un nuevo disparo
    /// </summary>
    private void Shot()
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
}