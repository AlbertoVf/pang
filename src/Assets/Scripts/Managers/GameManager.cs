using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IEReady());
    }


    // Update is called once per frame
    void Update()
    {

    }
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
