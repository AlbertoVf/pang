using UnityEngine;

public class AspectUtility : MonoBehaviour
{
    #region Public Fields

    public float _wantedAspectRatio = 1.77778f;

    #endregion Public Fields

    #region Private Fields

    private static Camera backgroundCam;
    private static Camera cam;
    private static float wantedAspectRatio;

    #endregion Private Fields

    #region Public Properties

    public static Vector2 GuiMousePosition
    {
        get
        {
            Vector2 mousePos = Event.current.mousePosition;
            mousePos.y = Mathf.Clamp(mousePos.y, cam.rect.y * Screen.height, cam.rect.y * Screen.height + cam.rect.height * Screen.height);
            mousePos.x = Mathf.Clamp(mousePos.x, cam.rect.x * Screen.width, cam.rect.x * Screen.width + cam.rect.width * Screen.width);
            return mousePos;
        }
    }

    public static Vector3 MousePosition
    {
        get
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.y -= (int)(cam.rect.y * Screen.height);
            mousePos.x -= (int)(cam.rect.x * Screen.width);
            return mousePos;
        }
    }

    public static int ScreenHeight
    {
        get
        {
            return (int)(Screen.height * cam.rect.height);
        }
    }

    public static Rect ScreenRect
    {
        get
        {
            return new Rect(cam.rect.x * Screen.width, cam.rect.y * Screen.height, cam.rect.width * Screen.width, cam.rect.height * Screen.height);
        }
    }

    public static int ScreenWidth
    {
        get
        {
            return (int)(Screen.width * cam.rect.width);
        }
    }

    public static int XOffset
    {
        get
        {
            return (int)(Screen.width * cam.rect.x);
        }
    }

    public static int YOffset
    {
        get
        {
            return (int)(Screen.height * cam.rect.y);
        }
    }

    #endregion Public Properties

    #region Public Methods

    public static void SetCamera()
    {
        float currentAspectRatio = (float)Screen.width / Screen.height;
        // If the current aspect ratio is already approximately equal to the desired aspect ratio,
        // use a full-screen Rect (in case it was set to something else previously)
        if ((int)(currentAspectRatio * 100) / 100.0f == (int)(wantedAspectRatio * 100) / 100.0f)
        {
            cam.rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
            if (backgroundCam)
            {
                Destroy(backgroundCam.gameObject);
            }
            return;
        }
        // Pillarbox
        if (currentAspectRatio > wantedAspectRatio)
        {
            float inset = 1.0f - wantedAspectRatio / currentAspectRatio;
            cam.rect = new Rect(inset / 2, 0.0f, 1.0f - inset, 1.0f);
        }
        // Letterbox
        else
        {
            float inset = 1.0f - currentAspectRatio / wantedAspectRatio;
            cam.rect = new Rect(0.0f, inset / 2, 1.0f, 1.0f - inset);
        }
        if (!backgroundCam)
        {
            // Make a new camera behind the normal camera which displays black; otherwise the unused space is undefined
            backgroundCam = new GameObject("BackgroundCam", typeof(Camera)).GetComponent<Camera>();
            backgroundCam.depth = int.MinValue;
            backgroundCam.clearFlags = CameraClearFlags.SolidColor;
            backgroundCam.backgroundColor = Color.black;
            backgroundCam.cullingMask = 0;
        }
    }

    #endregion Public Methods

    #region Private Methods

    private void Awake()
    {
        cam = GetComponent<Camera>();
        if (!cam)
        {
            cam = Camera.main;
        }
        if (!cam)
        {
            Debug.LogError("No camera available");
            return;
        }
        wantedAspectRatio = _wantedAspectRatio;
        SetCamera();
    }

    #endregion Private Methods
}