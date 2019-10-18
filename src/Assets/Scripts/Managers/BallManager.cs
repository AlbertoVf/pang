using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public static BallManager bm;
    public List<GameObject> balls = new List<GameObject>();
    public bool spliting;//comprueba si esta explotando
    private void Awake()
    {
        if (bm == null)
        {
            bm = this;
        }
        else if (bm != this)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        balls.AddRange(GameObject.FindGameObjectsWithTag("Ball"));
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartGame()
    {
        foreach (GameObject item in balls)
        {
            if (balls.IndexOf(item) % 2 == 0)
            {
                item.GetComponent<Ball>().right = true;
            }
            else
            {
                item.GetComponent<Ball>().right = false;
            }
            item.GetComponent<Ball>().StartForce(item);
        }
    }
    public void DestroyBall(GameObject ball, GameObject ball1, GameObject ball2)
    {
        balls.Remove(ball);
        Destroy(ball);
        balls.Add(ball1);
        balls.Add(ball2);
    }

    public void LastBall(GameObject ball)
    {
        Destroy(ball);
        balls.Remove(ball);
    }

    public void Dynamite(int maxNumberBalls)
    {
        StartCoroutine(IEDynamiteBH(maxNumberBalls));
    }

    /// <summary>
    /// Finds the balls. Comprueba todos los componentes que estan en escena buscando las bolas que tengan el mismo tipo que se pasa por parametro y destrullendolas hasta alcancar el nivel mas pequeño
    /// </summary>
    /// <param name="typeOfBall">The type of ball. Tipo de bola numerado desde el 5 hacia bajo, desde el mayor al menor</param>
    /// <returns>Lista con las bolas que se van a destruir</returns>
    List<GameObject> FindBalls(int typeOfBall)
    {
        List<GameObject> ballsToDestroy = new List<GameObject>();
        for (int i = 0; i < balls.Count; i++)
        {
            if (balls[i].GetComponent<Ball>().name.Contains(typeOfBall.ToString()) && balls[i] != null)
            {
                ballsToDestroy.Add(balls[i]);
            }
        }
        return ballsToDestroy;
    }
    /// <summary>
    /// Reloads the list. Recarga la lista de bolas en juego
    /// </summary>
    void ReloadList()
    {
        balls.Clear();
        balls.AddRange(GameObject.FindGameObjectsWithTag("Ball"));
    }

    /// <summary>
    /// Ies the dynamite bh. Explosion de bolas hasta alcanzar un numero determinado
    /// </summary>
    /// <param name="maxNumberBalls">The maximum number balls.</param>
    /// <returns></returns>
    public IEnumerator IEDynamiteBH(int maxNumberBalls)
    {
        ReloadList();
        spliting = true;
        int numberToFind = 1;
        while (numberToFind < maxNumberBalls)
        {
            foreach (GameObject item in FindBalls(numberToFind))
            {
                item.GetComponent<Ball>().Split();
                Destroy(item);
            }
            yield return new WaitForSeconds(General.tiempo["parpadeo"]);
            ReloadList();
            numberToFind++;
        }
        spliting = false;
    }
}
