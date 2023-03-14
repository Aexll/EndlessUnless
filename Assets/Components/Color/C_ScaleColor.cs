using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class C_ScaleColor : MonoBehaviour
{

    [SerializeField] private Color color;
    public UnityEvent<Color> OnColorScaled;

    public void ScaleAlpha(float alpha)
    {
        color.a = alpha;
        OnColorScaled?.Invoke(color);
    }

    public void SetColor(Color color)
    {
        OnColorScaled?.Invoke(color);
    }

}
