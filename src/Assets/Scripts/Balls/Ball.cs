using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject nextBall;
    Rigidbody2D rb;
    public bool right;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Explotan las bolas y se dividen
    /// </summary>
    public void Split()
    {
        if (nextBall != null)
        {
            GameObject ball1 = Instantiate(nextBall, rb.position + Vector2.right / 4, Quaternion.identity);
            GameObject ball2 = Instantiate(nextBall, rb.position + Vector2.left / 4, Quaternion.identity);

            ball1.GetComponent<Rigidbody2D>().AddForce(new Vector2(2, 5), ForceMode2D.Impulse);
            ball1.GetComponent<Ball>().right = false;

            ball2.GetComponent<Rigidbody2D>().AddForce(new Vector2(-2, 5), ForceMode2D.Impulse);
            ball2.GetComponent<Ball>().right = false;

            BallManager.bm.DestroyBall(gameObject, ball1, ball2);
        }
        else
        {
            BallManager.bm.LastBall(gameObject);
        }
    }
    public void StartForce(params GameObject[] balls)
    {
        for (int i = 0; i < balls.Length; i++)
        {
            if (right)
            {
                balls[i].GetComponent<Rigidbody2D>().AddForce(new Vector2(2, 0), ForceMode2D.Impulse);
            }
            else
            {
                balls[i].GetComponent<Rigidbody2D>().AddForce(new Vector2(-2, 0), ForceMode2D.Impulse);
            }
        }
    }
}
