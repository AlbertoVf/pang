using Assets.Scripts;

using System.Collections;

using UnityEngine;

public class BallGenerator : MonoBehaviour
{
    #region Public Fields

    public static BallGenerator bg;
    public GameObject[] ballsPrefab;
    public bool free;

    #endregion Public Fields

    #region Private Fields

    private GameObject ball = null;

    #endregion Private Fields

    #region Public Methods

    public void NewBall()
    {
        if (!FreezeManager.fm.freeze)
        {
            ball = Instantiate(ballsPrefab[Random.Range(0, ballsPrefab.Length)], new Vector2(Random.Range(-7, 7), transform.position.y), Quaternion.identity);
            BallManager.bm.balls.Add(ball);
            StartCoroutine(IEMoveDown());
        }
    }

    #endregion Public Methods

    #region Private Methods

    private void Awake()
    {
        if (bg == null)
        {
            bg = this;
        }
        else if (bg != this)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator IEMoveDown()
    {
        yield return new WaitForSeconds(Tiempo.TEXTO);
        while (!free)
        {
            ball.transform.position = new Vector2(ball.transform.position.x, ball.transform.position.y - 0.5f);
            yield return new WaitForSeconds(Tiempo.TEXTO);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //generar bolas en un rango de [-7,7]x
        if (collision.gameObject.tag == "Ball")
        {
            free = false;
        }
    }

    private void Update()
    {
        if (ball != null && ball.transform.position.y <= 4.4f && !free)
        {
            free = true;
            ball.GetComponent<Ball>().StartForce(ball);
        }
    }

    #endregion Private Methods

    // instanciar bola
}