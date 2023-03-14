using UnityEngine;

public class AutoCameraSize : MonoBehaviour
{
    public float minSize = 1f;
    public float maxSize = 100f;
    public float padding = 1f;
    public Bounds bounds;

    void Start()
    {
        ResizeCamera();
    }

    void ResizeCamera()
    {
        Camera camera = GetComponent<Camera>();
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float boundsRatio = bounds.size.x / bounds.size.y;

        float newSize = camera.orthographicSize;

        if (screenRatio >= boundsRatio)
        {
            newSize = (bounds.size.x / 2f + padding) / screenRatio;
        }
        else
        {
            newSize = bounds.size.y / 2f + padding;
        }

        newSize = Mathf.Clamp(newSize, minSize, maxSize);
        camera.orthographicSize = newSize;
    }

    void OnScreenResized()
    {
        ResizeCamera();
    }

    void OnEnable()
    {
        Canvas canvas = GetComponentInParent<Canvas>();
        if (canvas != null)
        {
            canvas.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
        }
    }

    void OnRectTransformDimensionsChange()
    {
        OnScreenResized();
    }

/*    Bounds CalculateBounds()
    {
        Bounds bounds = new Bounds(Vector3.zero, Vector3.zero);

        foreach (Renderer renderer in FindObjectsOfType<Renderer>())
        {
            if (renderer.gameObject.layer == LayerMask.NameToLayer("UI"))
            {
                continue;
            }

            bounds.Encapsulate(renderer.bounds);
        }

        return bounds;
    }*/

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(bounds.center, bounds.size);
    }
}
