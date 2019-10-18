using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    private void Awake()
    {
        if (gm == null)
        {
            gm = this;
        }
        else if (gm != null)
        {
            Destroy(gameObject);
        }
    }
    public IEnumerator IEReady()
    {
        StartCoroutine(IEGameStart());
        yield return null;
    }
    public IEnumerator IEGameStart()
    {
        yield return null;
    }
}
