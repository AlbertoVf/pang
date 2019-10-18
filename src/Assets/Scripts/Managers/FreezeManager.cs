using Assets.Scripts;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FreezeManager : MonoBehaviour
{

    public static FreezeManager fm;
    public Text freezeTimeText;
    public GameObject freezeTimeCount;
    float freezeTime;
    public bool freeze;
    private void Awake()
    {
        if (fm == null)
        {
            fm = this;
        }
        else if (fm != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        freezeTimeCount.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartFreeze()
    {
        freezeTime = General.tiempo["cuentaAtras"];
        if (!freeze)
        {
            StartCoroutine(IEFreezeTime());
        }
    }
    public IEnumerator IEFreezeTime()
    {
        freeze = true;
        foreach (GameObject item in BallManager.bm.balls)
        {
            if (item != null)
            {
                item.GetComponent<Ball>().FreezeBall(item);
            }
        }
        freezeTimeCount.SetActive(true);
        while (freezeTime > 0)
        {
            freezeTime -= Time.deltaTime;
            freezeTimeText.text = freezeTime.ToString("f2");
            yield return null;//espera a cada fotograma

        }
        freezeTimeCount.SetActive(false);
        freezeTime = 0;
        foreach (GameObject item in BallManager.bm.balls)
        {
            if (item != null)
            {
                item.GetComponent<Ball>().UnfreezeBall(item);
            }
        }
        freeze = false;
    }
}
