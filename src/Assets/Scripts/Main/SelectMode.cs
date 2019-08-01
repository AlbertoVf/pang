using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SelectMode : MonoBehaviour
{
    public Image tourModeImage;
    public Text tourModeText;
    public Image panicModeImage;
    public Text panicModeText;

    bool tour;
    // Start is called before the first frame update
    void Start()
    {
        tour = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (tour)
        {
            tourModeImage.color = new Color(1, 1, 1);
            tourModeText.color = new Color(1, 1, 1);

            panicModeImage.color = new Color(1, 1, 0,0.5f);
            panicModeText.color = new Color(1, 1, 1,0.5f);

            if (Input.GetKeyDown(General.teclas["derecha"]))
            {
                tour = false;
            }
            General.CargarEscena("TourMode_01");
        }
        else
        {
            panicModeImage.color = new Color(1, 1, 1);
            panicModeText.color = new Color(1, 1, 1);

            tourModeImage.color = new Color(1, 1, 0, 0.5f);
            tourModeText.color = new Color(1, 1, 1, 0.5f);

            if (Input.GetKeyDown(General.teclas["izquierda"]))
            {
                tour = true;
            }
            General.CargarEscena("PanicMode");
        }
    }
}
