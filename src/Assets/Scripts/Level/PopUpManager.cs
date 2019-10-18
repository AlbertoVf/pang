using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    public GameObject popUpText;

    public static PopUpManager pm;
    private void Awake()
    {
        if (pm == null)
        {
            pm = this;
        }
        else if (pm != null)
        {
            Destroy(gameObject);
        }
    }
    public void InstanciatePopUpText(Vector2 starPos,int textScore)
    {
        GameObject pop = Instantiate(popUpText);
        pop.transform.position = starPos;
        pop.GetComponent<TextMesh>().text = textScore.ToString();
    }
}
