using Assets.Scripts;
using UnityEngine;
public class PressStart : MonoBehaviour
{
    public GameObject pressStart;
    float time;

    // Update is called once per frame
    void Update()
    {
        ParpadeoTexto(pressStart);
        General.CargarEscena(1);
    }

    void ParpadeoTexto(GameObject gm)
    {
        time += Time.deltaTime;
        if (Mathf.RoundToInt(time) % 2 == 0)
        {
            gm.SetActive(true);
        }
        else
        {
            gm.SetActive(false);
        }
    }
}
